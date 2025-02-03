using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcOrientation : MonoBehaviour
{

    float horizontalInputMouse;
    float verticalInputMouse;

    public float angleY;

    // public GameObject player;

    Vector3 viewDir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void RotateNpc(Vector3 playerTransform, float rotationSpeed)
    {
        viewDir = (playerTransform - transform.position);

        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, viewDir);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed);

        angleY = Mathf.Atan2(viewDir.y, viewDir.x) * Mathf.Rad2Deg;

        
    }
}
