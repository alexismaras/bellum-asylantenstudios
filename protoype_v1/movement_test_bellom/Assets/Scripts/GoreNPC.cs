using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoreNPC : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameSounds gameSounds;

    [SerializeField] MainManager mainManager;

    [SerializeField] GoreMeter goreMeter;

    public float health = 4;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        spriteRenderer.material.color = new Color(1.0f, 0.25f * health, 0.0f, 1.0f);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     Debug.Log("Typeshit");
    //     if (collision.gameObject.tag == "ProjectileInstance")
    //     {
    //         BulletBehaviour bullet_behaviour = collision.gameObject.GetComponent<BulletBehaviour>();
    //         float volume = bullet_behaviour.volume;
    //         health -= volume;
    //     }

        
    // }

    private void OnDestroy()
    {
        goreMeter.RaiseGoremeter(10);
    }


}
