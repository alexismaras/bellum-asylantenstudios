using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public GameObject player;

    public float bullet_speed;
    public float volume;

    public Vector3 bulletDir;


    Rigidbody2D bullet_rb;

    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag =="ProjectileInstance")
        {
            bullet_rb = GetComponent<Rigidbody2D>();
            StartCoroutine(BulletLifetime());
            bulletDir = playerMovement.viewDir;
            transform.position = player.transform.position;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, bulletDir);
            volume = 1;
            bullet_rb.AddForce(bulletDir * bullet_speed * 100);
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.tag =="ProjectileInstance")
        {
            if (volume <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    IEnumerator BulletLifetime()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
