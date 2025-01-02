using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrientation : MonoBehaviour
{
    float horizontalInputMouse;
    float verticalInputMouse;

    // public GameObject player;

    Vector3 viewDir;

    Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // viewDir = transform.position - mousePos;

        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

        // if (Input.GetKeyDown(KeyCode.A))
        // {
        //     Debug.Log('A');
        // }
        // if (Input.GetKeyDown(KeyCode.W))
        // {
        //     Debug.Log('W');
        // }
        // if (Input.GetKeyDown(KeyCode.S))
        // {
        //     Debug.Log('S');
        // }
        // if (Input.GetKeyDown(KeyCode.D))
        // {
        //     Debug.Log('D');
        // }
        
        
    }
}
