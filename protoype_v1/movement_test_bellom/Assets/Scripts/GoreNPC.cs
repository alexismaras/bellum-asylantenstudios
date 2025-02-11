using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoreNPC : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] Sprite deadEnemySprite;
    [SerializeField] GameSounds gameSounds;

    [SerializeField] MainManager mainManager;

    [SerializeField] GoreMeter goreMeter;

    [SerializeField] DialogManager dialogManager;

    [SerializeField] Transform orientation;

    [SerializeField] bool npcApproachable;
    [SerializeField] int dialogIndex;

    [SerializeField] bool fightsBack;

    [SerializeField] float rotationSpeed;
    [SerializeField] float moveSpeed;

    EnemyBulletManager enemyBulletManager;

    NpcOrientation npcOrientation;

    SpriteRenderer spriteRenderer;

    LayerMask playerLayerMask;

    Rigidbody2D rigidbody2D;

    public float health = 4;
    
    Vector3 circleCastOrigin;
    Vector3 circleCastOrigin2;
    bool approachWindow = false;

    public Vector3 viewDir;    

    void Start()
    {
        npcOrientation = GetComponentInChildren<NpcOrientation>();
        enemyBulletManager = GetComponentInChildren<EnemyBulletManager>();
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

    // void NpcApproachSystem()
    // {
    //     circleCastOrigin = new Vector3(transform.position.x, transform.position.y - 0.7f, transform.position.z);
    //     RaycastHit2D hit = Physics2D.CircleCast(circleCastOrigin, 1, Vector3.zero, 0, playerLayerMask);
    //     if (hit)
    //     {
    //         approachColliderHitTag = hit.collider.tag;
    //         if (hit.collider.tag == "Player")
    //         {
    //             StartCoroutine(ApproachTimeWindow());
    //         }
    //     }
    //     else
    //     {
    //         approachColliderHitTag = "";
    //     }
    // }

    void NpcApproachSystem()
    {

        GameObject sideQuest = transform.Find("SidequestSign").gameObject;
        SpriteRenderer sideQuestRenderer = sideQuest.GetComponent<SpriteRenderer>();
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= 1.5f)
        {
            approachWindow = true;
            StartCoroutine(ApproachTimeWindow());
            if (!sideQuestRenderer.enabled)
            {
                sideQuestRenderer.enabled = true;
            }
        }
        else
        {
            approachWindow = false;
            if (sideQuestRenderer.enabled)
            {
                sideQuestRenderer.enabled = false;
            }
        }

    }
    
    IEnumerator ApproachTimeWindow()
    {
        while (approachWindow)
        {
            yield return null;
            if (!dialogManager.approachActive)
            {
                dialogManager.dialogIndex = dialogIndex;
                dialogManager.approachActive = true;
            }
        }
        dialogManager.approachActive = false;
    }

    // void NpcCombatSystem()
    // {
    //     circleCastOrigin = new Vector3(transform.position.x, transform.position.y - 0.7f, transform.position.z);

    //     Collider2D hitCollider = Physics2D.OverlapCircle(circleCastOrigin, 4f, playerLayerMask);

    //     // Debug.Log(hitCollider.gameObject.name);
    //     if (hitCollider != null && hitCollider.tag == "Player")
    //     {
    //         npcOrientation.RotateNpc(hitCollider.transform.position, rotationSpeed);
    //         FollowPlayer(hitCollider.transform.position);
    //         enemyBulletManager.shooting = true;
    //     }
    //     else
    //     {
    //         enemyBulletManager.shooting = false;
    //     }
    // }

    void NpcCombatSystem()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= 6f)
        {
            npcOrientation.RotateNpc(player.transform.position, rotationSpeed);
            enemyBulletManager.shooting = true;
            if (distance >= 4f && distance <= 6f)
            {
                FollowPlayer(player.transform.position);
                
            }
            else if (distance <= 3f)
            {
                BackUpFromPlayer(player.transform.position);
            }
        }
    }

    void FollowPlayer(Vector3 playerTransform)
    {
        Vector3 moveDir = (playerTransform - transform.position);
        rigidbody2D.MovePosition(transform.position + moveDir * moveSpeed);
    }

    void BackUpFromPlayer(Vector3 playerTransform)
    {
        Vector3 moveDir = (transform.position- playerTransform);
        rigidbody2D.MovePosition(transform.position + moveDir * moveSpeed);
    }

    void HealthSystem()
    {
        if (health <= 0)
        {
            enemyBulletManager.shooting = false;
            Destroy(gameObject);
            CreateDeadbodyInstance();
        }
    }
    void OnDestroy()
    {
        goreMeter.RaiseGoremeter();
    }

    void CreateDeadbodyInstance()
    {
        GameObject deadEnemyBody = Instantiate(gameObject, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z), transform.rotation);
        deadEnemyBody.GetComponent<GoreNPC>().enabled = false;
        deadEnemyBody.GetComponent<Rigidbody2D>().simulated = false;
        deadEnemyBody.GetComponent<Collider2D>().enabled = false;
        deadEnemyBody.transform.Find("Hitbox").gameObject.SetActive(false);
        deadEnemyBody.transform.Find("EnemyAnimationManager").gameObject.SetActive(false);
        deadEnemyBody.transform.Find("EnemyOrientation").gameObject.SetActive(false);
        deadEnemyBody.transform.Find("EnemySprite").gameObject.GetComponent<SpriteRenderer>().sprite = deadEnemySprite;
        deadEnemyBody.transform.Find("EnemySprite").gameObject.GetComponent<EnemySort>().enabled = true;
        deadEnemyBody.transform.Find("EnemyBullet").gameObject.SetActive(false);
        deadEnemyBody.transform.Find("EnemyBulletManager").gameObject.SetActive(false);
        foreach (Transform childTransform in deadEnemyBody.transform)
        {   
            if (childTransform.gameObject.tag == "ProjectileInstance")
            {
                Destroy(childTransform.gameObject);
            }
        }
        deadEnemyBody.SetActive(true);
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
            Gizmos.DrawWireSphere(circleCastOrigin, 5f);

            circleCastOrigin2 = new Vector3(transform.position.x, transform.position.y - 0.7f, transform.position.z);
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(circleCastOrigin2, 3f);
        }
    }
}