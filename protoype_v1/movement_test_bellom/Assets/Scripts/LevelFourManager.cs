using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFourManager : MonoBehaviour
{
    [SerializeField] DialogManager dialogManager;

    [SerializeField] SceneSwitcher sceneSwitcher;

    [SerializeField] GameSounds gameSounds;

    bool gunshotAlreadyPlayed;

    bool dialogStarted = false;

    bool playGunshot;

    // Start is called before the first frame update
    void Start()
    {
        dialogStarted = false;
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
            dramaticGunshotPlay();
            sceneSwitcher.ChangeScene();
        }
    }

    private void dramaticGunshotPlay()
    {
        gameSounds.PlayDramaticGunshot();
        gunshotAlreadyPlayed = true;
    }

    //if (playGunshot)
        //{
          //  StartCoroutine(dramaticGunshotPlay());
        //}
}
