using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CornerWallSor : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement; 
    SpriteRenderer spriteRenderer;

    [SerializeField] float offset; 

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        if (playerMovement.transform.position.y < transform.position.y + offset)
        {
            spriteRenderer.sortingLayerName = "WallBehindPlayer";
            // spriteRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * -100) - 1;
        }
        else
        {
            // spriteRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * -100) + 1;
            spriteRenderer.sortingLayerName = "WallBeforePlayer";
        }
    }
}
