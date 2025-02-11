using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoreMeter : MonoBehaviour
{

    [SerializeField]
    PlayerMovement playerMovement;

    [SerializeField]
    BulletManager bulletManager;

    [SerializeField]
    AnimationManager animationManager;

    public bool goreMeterActive;

    public int goreMeterScore;
    int goreMeterLimit = 100;


    // Start is called before the first frame update
    void Start()
    {
        goreMeterScore = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        // goreMeterMultiplier an bestimmte Scripts weitergeben
        if (goreMeterScore > 0 && goreMeterActive)
        {
            float internalGoreMeterMultiplier = (float)goreMeterScore/goreMeterLimit;

            playerMovement.goreMeterMultiplier = internalGoreMeterMultiplier;

            bulletManager.goreMeterMultiplier = internalGoreMeterMultiplier;

            animationManager.goreMeterMultiplier = internalGoreMeterMultiplier;

        }

        // goreMeterMultiplier 0 setzen, um ZeroDivision zu vermeiden
        else
        {
            playerMovement.goreMeterMultiplier = 0;
            bulletManager.goreMeterMultiplier = 0;
            animationManager.goreMeterMultiplier = 0;
        }
    }

    public void RaiseGoremeter()
    {
        // Funktion um den goreMeterScore von anderen Scripts aus zu erhöhren
        if (goreMeterScore < goreMeterLimit)
        {
            goreMeterScore += 10;
        }
    }
}
