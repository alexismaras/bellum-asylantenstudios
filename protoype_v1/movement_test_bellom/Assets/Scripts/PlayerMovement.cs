using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    Rigidbody2D rigidbody2D;
    public Transform orientation;
    float horizontalInput;

    
    float verticalInput;
    public bool moving;

    
    
    public Vector3 inputDir;
    public Vector3 viewDir;
    public GameObject camera;

    public BulletManager bulletManager;

    public float goreMeterMultiplier;


    LayerMask layerMask;

    // public Animator animator;

    [Header("Movement")]
    public float moveSpeed;
    public float fastRollSpeed;
    public float walkingShootMultiplier;
    public bool fastRollPerforming;
    public float fastRollTimer;

    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        fastRollSpeed = 10;
        layerMask = LayerMask.GetMask("Entity");
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (moving && !bulletManager.shooting)
                FastRollMove();
        }
        horizontalInput = Input.GetAxisRaw("Horizontal");
        moving = Input.GetMouseButton(1);

        if (moving)
        {
            verticalInput = 1;
        }
        else
        {
            verticalInput = 0;
        }
        
        inputDir = orientation.up * verticalInput;
        viewDir = orientation.up * 1f;



        Debug.DrawRay(transform.position, viewDir * 20f, Color.white, 0.0f, false);
   
    }
    private void MovePlayer()
    {
        rigidbody2D.MovePosition(transform.position + inputDir * (moveSpeed+(moveSpeed*goreMeterMultiplier)) * (fastRollPerforming? fastRollSpeed : 1) * (bulletManager.shooting? walkingShootMultiplier : 1));
        // transform.position = transform.position + inputDir * (moveSpeed+(moveSpeed*goreMeterMultiplier)) * (fastRollPerforming? fastRollSpeed : 1) * (bulletManager.shooting? walkingShootMultiplier : 1);
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);

        Debug.Log(goreMeterMultiplier);
        
    }

    void FastRollMove()
    {
        fastRollPerforming = true;
        fastRollTimer = 10;

    }

    void FastRollReset()
    {  
        if (fastRollTimer > 0)
        {
            fastRollTimer -= 1;
        }
        else
        {
            fastRollPerforming = false;
        }
    }


    void FixedUpdate()
    {
        FastRollReset();
        MovePlayer();
        if (Input.GetMouseButton(0) && !fastRollPerforming)
        {   
            bulletManager.shooting = true;
        }
        else 
        {
            bulletManager.shooting = false;
        }
        // animator.SetBool("shooting", bulletManager.shooting);
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Etz aber");
    }
}
