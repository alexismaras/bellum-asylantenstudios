using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MonologTrigger_Lvl2 : MonoBehaviour
{
    public PlayerMovement PlayerMovement;
    public DialogManager DialogManager;
    [SerializeField] TextMeshProUGUI uiDialogInfo;
    [SerializeField] TextMeshProUGUI MagazineInfo;
    string MonoLogLvl2 = "Can´t screw this up again... just follow orders.";
    bool alreadyPlayed = false;

    void Start()
    {
        uiDialogInfo.text = $"";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("SpaceBar!");
            EndMonolog();
            alreadyPlayed = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!alreadyPlayed)
        {
            Debug.Log("Dabei");
            StartMonolog();
        }
    }

    void StartMonolog()
    {
        uiDialogInfo.text = MonoLogLvl2;
        PlayerMovement.playerDialogActive = true;
        MagazineInfo.rectTransform.anchoredPosition += new Vector2 (0, 67.5f);
    }

    void EndMonolog()
    {
        uiDialogInfo.text = $"";
        PlayerMovement.playerDialogActive = false;
        MagazineInfo.rectTransform.anchoredPosition -= new Vector2(0, 67.5f);
    }
}
