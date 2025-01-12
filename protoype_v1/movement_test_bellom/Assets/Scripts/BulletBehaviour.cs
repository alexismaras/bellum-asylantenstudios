using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    BulletManager bulletManager;

    [SerializeField]
    PlayerMovement playerMovement;

    [SerializeField]
    GameSounds gameSounds;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    LayerMask layerMask;

    [SerializeField]
    float bulletPlacement;

    float bulletSpeed;
    public float volume;

    float goremeterMultiplier;

    Vector3 bulletDir;

    Vector3 previousPosition;
    Vector3 currentPosition;

    
    bool bulletHasSpray;
    int randomSprayValue;

    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (gameObject.tag =="ProjectileInstance")
        {   
            spriteRenderer.enabled = true;
            bulletSpeed = bulletManager.bulletSpeed;
            volume = bulletManager.volume;
            

            layerMask = LayerMask.GetMask("Entity");
            bulletDir = playerMovement.viewDir;
            randomSprayValue = Random.Range(1, 3);
            if (randomSprayValue == 1)
            {
                bulletHasSpray = true;
            }
            else
            {
                bulletHasSpray = false;
            }
            if (bulletHasSpray)
            {
                bulletDir.x += Random.Range(-0.03f, 0.03f);
                bulletDir.y += Random.Range(-0.03f, 0.03f);
            }
            transform.position = player.transform.position + bulletDir * bulletPlacement;
            currentPosition = transform.position;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, bulletDir);
            volume = 1;
        }

        else
        {
            spriteRenderer.enabled = false;
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.tag =="ProjectileInstance")
        {
            MoveBullet();
            if (volume <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    void MoveBullet()
    {
        previousPosition = currentPosition;
        transform.position = transform.position + bulletDir * bulletSpeed;
        currentPosition = transform.position;
        Debug.DrawRay(previousPosition, currentPosition-previousPosition, Color.red, 0f, false); 
        RaycastHit2D hit = Physics2D.Raycast(previousPosition, currentPosition-previousPosition, bulletSpeed, layerMask);
        if (hit)
        {  
            if (hit.collider.tag == "Enemy")
            {
                gameSounds.PlayHitmarker();
                ShootableObject shootableObject = hit.collider.GetComponent<ShootableObject>();
                shootableObject.health -= volume;
                volume -= shootableObject.hardness;
                Debug.DrawRay(previousPosition, currentPosition-previousPosition, Color.white, 10f, false); 
            }
            else if (hit.collider.tag == "NPC")
            {
                gameSounds.PlayHitmarker();
                GoreNPC goreNPC = hit.collider.GetComponent<GoreNPC>();
                goreNPC.health -= volume;
                volume -= goreNPC.hardness;
                Debug.DrawRay(previousPosition, currentPosition-previousPosition, Color.white, 10f, false); 
            }
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
