using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public GameObject player;

    public float bullet_speed;
    public float volume;

    public Vector3 bulletDir;

    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag =="ProjectileInstance")
        {
            StartCoroutine(BulletLifetime());
            bulletDir = playerMovement.viewDir;
            transform.position = player.transform.position;
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


    public void MoveBullet()
    {
        for (var i = 0; i < bullet_speed; i++)
        {
            transform.position = transform.position + bulletDir * 0.1f;
        }
    }
    IEnumerator BulletLifetime()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
