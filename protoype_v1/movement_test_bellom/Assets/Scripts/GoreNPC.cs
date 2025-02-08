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
    [SerializeField] float moveSpeed;

    Rigidbody2D rigidbody2D;

    public float health = 4;
    
    Vector3 circleCastOrigin;

    Vector3 viewDir;

    LayerMask playerLayerMask;


    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        playerLayerMask = LayerMask.GetMask("Player");
    }

    void Update()
    {
        HealthSystem();

        viewDir = orientation.up * 1f;

        Debug.DrawRay(transform.position, viewDir * 20f, Color.white, 0.0f, false);
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
                dialogManager.approachActive = false;
            }
        }
    }

    // void NpcCombatSystem()
    // {
    //     circleCastOrigin = new Vector3(transform.position.x, transform.position.y - 0.7f, transform.position.z);
    //     RaycastHit2D hit = Physics2D.CircleCast(circleCastOrigin, 4, Vector3.zero, 0);
    //     if (hit)
    //     {
    //         Debug.Log(hit.collider);
    //         if (hit.collider.tag == "Player")
    //         {
    //             Debug.Log("PlayerHitCombat");
    //             // Vector3 npsToPlayerDirection = hit.collider.transform.position - transform.position;
    //             // float angle = Mathf.Atan2(npcToPlayerDirection.y, npcToPlayerDirection.x) * Mathf.Rad2Deg;
    //             npcOrientation.RotateNpc(hit.collider.transform.position, rotationSpeed);
    //             FollowPlayer(hit.collider.transform.position);
    //         }
    //     }
    // }
    void NpcCombatSystem()
    {
        // Calculate the detection center based on the NPC's position
        circleCastOrigin = new Vector3(transform.position.x, transform.position.y - 0.7f, transform.position.z);
        
        // Check if any collider overlaps with the detection circle
        Collider2D hitCollider = Physics2D.OverlapCircle(circleCastOrigin, 4f, playerLayerMask);

        Debug.Log(hitCollider.gameObject.name);
        if (hitCollider.tag == "Player")
        {
            Debug.Log("PlayerHitCombat");
            npcOrientation.RotateNpc(hitCollider.transform.position, rotationSpeed);
            FollowPlayer(hitCollider.transform.position);
        }
    }

    void FollowPlayer(Vector3 playerTransform)
    {
        Vector3 moveDir = (playerTransform - transform.position);
        Debug.Log(moveDir);
        rigidbody2D.MovePosition(transform.position + moveDir * moveSpeed);
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
        
    }

    void OnDrawGizmos()
    {   
        if (npcApproachable)
        {
            circleCastOrigin = new Vector3(transform.position.x, transform.position.y - 0.7f, transform.position.z);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(circleCastOrigin, 1f);
        }
        if (fightsBack)
        {
            circleCastOrigin = new Vector3(transform.position.x, transform.position.y - 0.7f, transform.position.z);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(circleCastOrigin, 4f);
        }
    }
}