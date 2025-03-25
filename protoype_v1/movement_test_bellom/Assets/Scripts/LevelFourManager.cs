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

    public GameObject blackScreen;

    // Start is called before the first frame update
    void Start()
    {
        dialogStarted = false;
        blackScreen.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (dialogManager.dialogActive && !dialogStarted)
        {
            dialogStarted = true;
        }

        if (!dialogManager.dialogActive && dialogStarted && !gunshotAlreadyPlayed)
        {
            Debug.Log("Jetzt sollte der Sounds spielen");
            blackScreen.SetActive(true);
            dramaticGunshotPlay();
            sceneSwitcher.ChangeScene();
        }
    }

    private void dramaticGunshotPlay()
    {
        gameSounds.PlayDramaticGunshot();
        gunshotAlreadyPlayed = true;
    }
}
