using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoreNPC : MonoBehaviour
{
    public float health = 4;
    public float hardness = 0.4f;
    SpriteRenderer spriteR;
    public GameSounds gameSounds;

    public MainManager mainManager;

    public GoreMeter goreMeter;
    // Start is called before the first frame update
    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        spriteR.material.color = new Color(1.0f, 0.25f * health, 0.0f, 1.0f);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Typeshit");
        if (collision.gameObject.tag == "ProjectileInstance")
        {
            gameSounds.PlayHitmarker();
            BulletBehaviour bullet_behaviour = collision.gameObject.GetComponent<BulletBehaviour>();
            float volume = bullet_behaviour.volume;
            health -= volume;
            bullet_behaviour.volume -= hardness;
        }

        
    }

    private void OnDestroy()
    {
        goreMeter.RaiseGoremeter(10);
    }


}
