using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObject : MonoBehaviour
{
    float health = 3;
    float hardness = 0.4f;
    float health_before;
    SpriteRenderer spriteR;
    public GameSounds gamesounds;
    // Start is called before the first frame update
    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (health_before <= health)
        {
            spriteR.material.color = new Color(1.0f, 0.5f * health, 0.0f, 1.0f);
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        
        health_before = health;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Typeshit");
        if (collision.gameObject.tag == "ProjectileInstance")
        {
            gamesounds.PlayHitmarker();
            BulletBehaviour bullet_behaviour = collision.gameObject.GetComponent<BulletBehaviour>();
            float volume = bullet_behaviour.volume;
            health -= volume;
            bullet_behaviour.volume -= hardness;
        }

        
    }


}
