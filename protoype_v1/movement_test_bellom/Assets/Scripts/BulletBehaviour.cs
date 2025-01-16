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
    LayerMask layerMaskEntity;
    LayerMask layerMaskObjectCollider;

    float bulletSpeed;
    public float volume;

    float goremeterMultiplier;

    Vector3 bulletDir;

    Vector3 previousPosition;
    Vector3 currentPosition;

    
    bool bulletHasSpray;
    int randomSprayValue;

    bool firstInvoke = true;

    int raycastSegments = 8;


    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (gameObject.tag =="ProjectileInstance")
        {   
            spriteRenderer.enabled = false;
            bulletSpeed = bulletManager.bulletSpeed;
            volume = bulletManager.volume;
            layerMaskEntity = LayerMask.GetMask("Entity");
            layerMaskObjectCollider = LayerMask.GetMask("ObjectCollider");
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
            transform.position = player.transform.position;
            currentPosition = transform.position;
            previousPosition = currentPosition;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, bulletDir);
            volume = 1;
        }

        else
        {
            spriteRenderer.enabled = false;
        }
        
    }

    void FixedUpdate()
    {
        if (gameObject.tag =="ProjectileInstance")
        {
            MoveBullet();
        }

    }
    void MoveBullet()
    {
        // Beim ersten Aufruf der funktion bleibt previousPosition auf der Ursprünglichen-Position
        // Dannach wird previousPosition auf currentPosition gesetzt und currentPosition ist die neue Position des Projectils
        if (firstInvoke == false)
        {
            previousPosition = currentPosition;
        }
        transform.position = transform.position + bulletDir * bulletSpeed;
        currentPosition = transform.position;
        Debug.DrawRay(previousPosition, currentPosition-previousPosition, Color.red, 1f, false);
        
        // Dieser Loop spaltet die Distanz von previousPositon und currentPosition des Projectils in Segmente (raycastSegments) und checkt in welchem Segment sich der RaycastHit befindet
        for (var i = 0; i<raycastSegments; i++)
        {
            float dist = (Vector3.Distance(previousPosition, currentPosition))/raycastSegments;
            RaycastHit2D hit = Physics2D.Raycast(previousPosition + ((currentPosition-previousPosition)/raycastSegments) * i, currentPosition-previousPosition, dist, layerMaskEntity | layerMaskObjectCollider);
            if (hit)
            {  
                if (hit.collider.tag == "ShootableNpcHitbox")
                {
                    gameSounds.PlayHitmarker();
                    GameObject hitBox = hit.collider.gameObject;
                    Transform parentTransform = hitBox.transform.parent;
                    GoreNPC goreNPC = parentTransform.GetComponent<GoreNPC>();
                    goreNPC.health -= volume;
                    volume = 0;

                    Vector3 debugSegmentRayStart = previousPosition + ((currentPosition-previousPosition)/raycastSegments) * i;
                    Vector3 debugSegmentRayDirection = (currentPosition-previousPosition)/raycastSegments;
                    Debug.DrawRay(debugSegmentRayStart, debugSegmentRayDirection, Color.white, 10f, false);

                    Destroy(gameObject);
                    
                    break;
                }
                else if (hit.collider.tag == "Obstacle")
                {
                    Vector3 debugSegmentRayStart = previousPosition + ((currentPosition-previousPosition)/raycastSegments) * i;
                    Vector3 debugSegmentRayDirection = (currentPosition-previousPosition)/raycastSegments;
                    Debug.DrawRay(debugSegmentRayStart, debugSegmentRayDirection, Color.white, 10f, false);

                    Destroy(gameObject);

                    break;
                }
                if (hit.collider.tag == "Player")
                {
                    spriteRenderer.enabled = false;
                }
            }
            else
            {
                spriteRenderer.enabled = true; 
            }
        }
        //Beim ersten aufruf auf false gesetzt (siehe line 101)
        firstInvoke = false;
    }

    void OnBecameInvisible()
    {
        //Zerstört das gameObject sobald es ausser Sichtweite ist
        Destroy(gameObject);
    }
}
