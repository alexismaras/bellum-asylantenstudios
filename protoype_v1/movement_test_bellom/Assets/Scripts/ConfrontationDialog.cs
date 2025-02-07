using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConfrontationDialog : MonoBehaviour
{
    int dialogsenTextIndex = 0;
    public TextMeshProUGUI uiDialogInfo;
    public TextMeshProUGUI MagazineInfo;
    public PlayerMovement playerMovement;
    List<string> ConfrontationNPC = new List<string> { "You slaughtered my people.",
                                                   "My friends.",
                                                    "My family.",
                                                    "And yet",
                                                    "you call us the monsters.",
                                                    "...",
                                                    "Noone will miss you."};

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dialogsenTextIndex < (ConfrontationNPC.Count - 1))
            {
                NextDialogElement();
            }
            else
            {
                EndDialog();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerMovement.playerDialogActive = true;
        StartDialog();
    }

    void StartDialog()
    {
        dialogsenTextIndex = 0;
        uiDialogInfo.text = ConfrontationNPC[dialogsenTextIndex];
        MagazineInfo.rectTransform.anchoredPosition += new Vector2(0, 67.5f);
    }

    void NextDialogElement()
    {
        dialogsenTextIndex += 1;
        uiDialogInfo.text = ConfrontationNPC[dialogsenTextIndex];
    }

    void EndDialog()
    {
        MagazineInfo.rectTransform.anchoredPosition -= new Vector2(0, 67.5f);
    }
}
