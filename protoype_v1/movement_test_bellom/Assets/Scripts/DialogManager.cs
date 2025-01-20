using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI uiDialogInfo;
    [SerializeField] PlayerMovement playerMovement;
    bool dialogActive = false;
    public bool approachActive = false;

    List<string> dialog = new List<string> { "Salut MC!", "Die Monster müssen besiegt werden.", "Text3", "Text4"};

    int dialogTextIndex;


    // Start is called before the first frame update
    void Start()
    {
        uiDialogInfo.text = $"";   
    }

    // Update is called once per frame
    void Update()
    {
        if (!dialogActive)
        {
            playerMovement.playerDialogActive = false;
            uiDialogInfo.text = $"";   
        }
        else if (dialogActive)
        {
            playerMovement.playerDialogActive = true;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (dialogTextIndex < (dialog.Count - 1))
                {   
                    NextDialogElement();
                }
                else
                {
                    EndDialog();
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                EndDialog();
            }
        }
        if (approachActive)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartDialog();
                approachActive = false;
            }
        }
        
    }
    void StartDialog()
    {
        dialogActive = true;
        dialogTextIndex = 0;
        uiDialogInfo.text = dialog[dialogTextIndex];   
    }

    void NextDialogElement()
    {
        dialogTextIndex += 1;
        uiDialogInfo.text = dialog[dialogTextIndex];        
    }

    void EndDialog()
    {
        dialogActive = false;
    }
}
