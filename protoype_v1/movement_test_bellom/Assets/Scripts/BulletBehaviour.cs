using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public GameObject player;

    public float bullet_speed;
    public float volume;

    public GameSounds gamesounds;

    public Vector3 bulletDir;

    public bool bulletHasSpray;

    public int randomValue;
    public Color rancolor;

    public Vector3 previousPosition;
    public Vector3 currentPosition;

    LayerMask layerMask;

    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag =="ProjectileInstance")
        {
            layerMask = LayerMask.GetMask("Entity");
            StartCoroutine(BulletLifetime());
            bulletDir = playerMovement.viewDir;
            randomValue = Random.Range(1, 6);
            if (randomValue == 1 || randomValue == 2)
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
            transform.position = player.transform.position;
            currentPosition = transform.position;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, bulletDir);
            volume = 1;
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
        transform.position = transform.position + bulletDir * bullet_speed;
        Debug.Log(bulletDir);
        currentPosition = transform.position;
        Debug.DrawRay(previousPosition, currentPosition-previousPosition, Color.red, 0f, false); 
        RaycastHit2D hit = Physics2D.Raycast(previousPosition, currentPosition-previousPosition, bullet_speed, layerMask);
        if (hit)
        {  
            gamesounds.PlayHitmarker();
            ShootableObject shootableObject = hit.collider.GetComponent<ShootableObject>();
            shootableObject.health -= volume;
            volume -= shootableObject.hardness;
            Debug.DrawRay(previousPosition, currentPosition-previousPosition, Color.white, 10f, false);  
        }
    }
    IEnumerator BulletLifetime()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
