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
        uiDialogInfo.text = $"Du kleiner Go";   
    }

    void EndDialog()
    {
        dialogActive = false;
    }
}
