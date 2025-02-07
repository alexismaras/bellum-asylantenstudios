using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Transform TeleportDestination;
    public GameObject Player;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
            Player.transform.position = TeleportDestination.position;
    }
}
