using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneManager : MonoBehaviour
{
    [SerializeField] DialogManager dialogManager;

    [SerializeField] NextLevelTrigger nextLevelTrigger;

    bool talkedToNpcOne;
    bool talkedToNpcTwo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogManager.dialogActive && dialogManager.dialogIndex == 0 && !talkedToNpcOne)
        {
            talkedToNpcOne = true;
        }

        if (dialogManager.dialogActive && dialogManager.dialogIndex == 1 && !talkedToNpcTwo)
        {
            talkedToNpcTwo = true;
        }

        if (talkedToNpcOne && talkedToNpcTwo && !nextLevelTrigger.isAvailable)
        {
            nextLevelTrigger.isAvailable = true;
        }
    }
}
