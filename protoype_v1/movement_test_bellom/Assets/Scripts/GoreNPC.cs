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

    [SerializeField] Transform orientation;

    [SerializeField] bool npcApproachable;

    [SerializeField] NpcOrientation npcOrientation;

    [SerializeField] bool fightsBack;

    [SerializeField] float rotationSpeed;
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
            NpcApproachSystem();
        }
        if (fightsBack)
        {
            NpcCombatSystem();
        }
        
    }

    void NpcApproachSystem()
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

    void NpcCombatSystem()
    {
        circleCastOrigin = new Vector3(transform.position.x, transform.position.y - 0.7f, transform.position.z);
        RaycastHit2D hit = Physics2D.CircleCast(circleCastOrigin, 4, Vector3.zero, 0);
        if (hit)
        {
            if (hit.collider.tag == "Player")
            {
                Debug.Log("PlayerHitCombat");
                // Vector3 npsToPlayerDirection = hit.collider.transform.position - transform.position;
                // float angle = Mathf.Atan2(npcToPlayerDirection.y, npcToPlayerDirection.x) * Mathf.Rad2Deg;
                npcOrientation.RotateNpc(hit.collider.transform.position, rotationSpeed);
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