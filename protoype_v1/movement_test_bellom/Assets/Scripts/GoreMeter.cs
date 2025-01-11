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

    int goreMeterSore;
    int goreMeterLimit = 100;


    // Start is called before the first frame update
    void Start()
    {
        goreMeterSore = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        // goreMeterMultiplier an bestimmte Scripts weitergeben
        if (goreMeterSore > 0)
        {
            float internalGoreMeterMultiplier = (float)goreMeterSore/goreMeterLimit;

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

    public void RaiseGoremeter(int raise)
    {
        // Funktion um den goreMeterScore von anderen Scripts aus um "rais" zu erhöhren
        goreMeterSore += raise;
    }
}
