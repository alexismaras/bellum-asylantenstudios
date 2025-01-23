using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoreNPC : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameSounds gameSounds;

    [SerializeField] MainManager mainManager;

    [SerializeField] GoreMeter goreMeter;

    [SerializeField] DialogManager dialogManager;

    [SerializeField] bool npcApproachable;
    [SerializeField] SceneSwitcher sceneSwitcher;

    public float health = 4;
    
    Vector3 circleCastOrigin;


    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        HealthSystem();
    }

    void FixedUpdate()
    {
        if (npcApproachable)
        {
            ApproachSystem();
        }
    }

    void ApproachSystem()
    {
        circleCastOrigin = new Vector3(transform.position.x, transform.position.y - 0.7f, transform.position.z);
        RaycastHit2D hit = Physics2D.CircleCast(circleCastOrigin, 1, Vector3.zero, 0);
        if (hit)
        {
            if (hit.collider.tag == "Player")
            {
                Debug.Log("PlayerHit");
                dialogManager.approachActive = true;
            }
            else
            {
                Debug.Log("NoHit");
                dialogManager.approachActive = false;
            }
        }
    }

    void HealthSystem()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnDestroy()
    {
        goreMeter.RaiseGoremeter(10);
        sceneSwitcher.ChangeScene();
    }

    void OnDrawGizmos()
    {   
        if (npcApproachable)
        {
            circleCastOrigin = new Vector3(transform.position.x, transform.position.y - 0.7f, transform.position.z);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(circleCastOrigin, 1f);
        }
    }
}