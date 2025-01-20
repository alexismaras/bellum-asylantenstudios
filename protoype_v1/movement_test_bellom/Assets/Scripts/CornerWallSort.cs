using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CornerWallSort : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement; 
    [SerializeField] GameObject playerSprite; 
    SpriteRenderer spriteRenderer;

    SpriteRenderer playerSpriteRenderer;

    float spriteOffset; 
    float playerOffset;
    float playerHeight;
    float spriteHeight;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer playerSpriteRenderer = playerSprite.GetComponent<SpriteRenderer>();
        spriteHeight = spriteRenderer.bounds.size.y;
        spriteOffset = spriteHeight * 0.5f;
        playerHeight = playerSpriteRenderer.bounds.size.y;
        playerOffset = playerHeight * 0.5f;
    }

    void Update()
    {

        if (playerMovement.transform.position.y - playerOffset < transform.position.y - spriteOffset)
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
