using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationManager : MonoBehaviour
{
    [SerializeField] GoreNPC goreNPC;

    [SerializeField] NpcOrientation npcOrientation;

    [SerializeField] Animator animator;
    
    public float goreMeterMultiplier;

    [SerializeField]
    float initAnimSpeed = 2f;

    [SerializeField]
    float maxAnimSpeed = 2.5f;


    void Start()
    {
    }

    void FixedUpdate()
    {
        // Spieler bewegt sich

        // Ausrichtung des Spielers
        if (-180f <= npcOrientation.angleY && npcOrientation.angleY <= -90f)
        {
            animator.SetInteger("orientation", 3);
        }
        else if (-90f < npcOrientation.angleY && npcOrientation.angleY <= 0f)
        {
            animator.SetInteger("orientation", 2);
        }
        else if (0f < npcOrientation.angleY && npcOrientation.angleY <= 90f)
        {
            animator.SetInteger("orientation", 1);
        }
        else if (90f < npcOrientation.angleY && npcOrientation.angleY <= 180f)
        {
            animator.SetInteger("orientation", 4);
        }

    }
}
