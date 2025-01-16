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


    // public Animator animator;

    [Header("Movement")]
    public float moveSpeed;
    public float walkingShootMultiplier;

    public bool playerDialogActive = false;

    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
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

        // Debug.DrawRay(transform.position, viewDir * 20f, Color.white, 0.0f, false);
   
    }
    void MovePlayer()
    {
        rigidbody2D.MovePosition(transform.position + inputDir * (moveSpeed+(moveSpeed*goreMeterMultiplier)) * (bulletManager.shooting? walkingShootMultiplier : 1));
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
        Debug.Log(goreMeterMultiplier);
        
    }

    void ShootGun()
    {
        bulletManager.shooting = Input.GetMouseButton(0)? true : false;
    }


    void FixedUpdate()
    {
        if (!playerDialogActive)
        {
            MovePlayer();
            ShootGun();
        }
    }

}
