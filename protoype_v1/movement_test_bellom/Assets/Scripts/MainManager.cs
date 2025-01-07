using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public bool level_completed;
    public SceneSwitcher sceneSwitcher;
    // Start is called before the first frame update
    void Start()
    {
        level_completed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (level_completed)
        {
            sceneSwitcher.ChangeScene();
        }
        
    }
}
