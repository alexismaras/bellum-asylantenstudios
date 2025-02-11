using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFourManager : MonoBehaviour
{
    [SerializeField] DialogManager dialogManager;

    [SerializeField] SceneSwitcher sceneSwitcher;

    bool dialogStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogManager.dialogActive && !dialogStarted)
        {
            dialogStarted = true;
        }

        if (!dialogManager.dialogActive && dialogStarted)
        {
            sceneSwitcher.ChangeScene();
        }

    }
}
