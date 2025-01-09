using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoreMeter : MonoBehaviour
{
    public int goremeter_score;

    public int limit = 100;

    public PlayerMovement player;
    public BulletManager bulletManager;
    // Start is called before the first frame update
    void Start()
    {
        goremeter_score = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if (goremeter_score > 0)
        {
            player.goremeter_multiplier = (float)goremeter_score/limit;

            bulletManager.goremeter_multiplier = (float)goremeter_score/limit;
        }
        else
        {
            player.goremeter_multiplier = 0;
            bulletManager.goremeter_multiplier = 0;
        }
    }

    public void RaiseGoremeter(int raise)
    {
        goremeter_score += raise;
    }
}
