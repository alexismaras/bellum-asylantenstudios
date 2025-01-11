using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrientation : MonoBehaviour
{

    float horizontalInputMouse;
    float verticalInputMouse;

    public float angleY;

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
        // Mauszeiger Position speichern
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Richtungvektor aus Playerposition und Mauszeigerposition
        viewDir = (mousePos - transform.position);

        // Rotation des GameObjects zu Mauszeiger
        transform.rotation = Quaternion.LookRotation(Vector3.forward, viewDir);

        // Winkel Speichen für Sprite Animation
        angleY = Mathf.Atan2(viewDir.y, viewDir.x) * Mathf.Rad2Deg;
        
    }
}
