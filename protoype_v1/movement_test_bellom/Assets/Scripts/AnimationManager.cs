using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField]
    PlayerMovement playerMovement;

    [SerializeField]
    PlayerOrientation playerOrientation;

    [SerializeField]
    Animator animator;
    
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
        if (playerMovement.moving)
        {
            animator.SetBool("moving", true);
        }
        else if (!playerMovement.moving)
        {
            animator.SetBool("moving", false);
        }

        // Ausrichtung des Spielers
        if (-180f <= playerOrientation.angleY && playerOrientation.angleY <= -90f)
        {
            animator.SetInteger("orientation", 3);
        }
        else if (-90f < playerOrientation.angleY && playerOrientation.angleY <= 0f)
        {
            animator.SetInteger("orientation", 2);
        }
        else if (0f < playerOrientation.angleY && playerOrientation.angleY <= 90f)
        {
            animator.SetInteger("orientation", 1);
        }
        else if (90f < playerOrientation.angleY && playerOrientation.angleY <= 180f)
        {
            animator.SetInteger("orientation", 4);
        }

        //Animation Laufgeschwindigkeit und Player Laufgeschwindigkeit abgleichen Part2 - Beihilfe von Musa
        animator.SetFloat("animSpeedMultiplier", ((initAnimSpeed + ((maxAnimSpeed - initAnimSpeed) * goreMeterMultiplier)) / initAnimSpeed));


    }
}
