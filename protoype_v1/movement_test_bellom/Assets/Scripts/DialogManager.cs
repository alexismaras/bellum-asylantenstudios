// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;

// public class DialogManager : MonoBehaviour
// {
//     [SerializeField] TextMeshProUGUI uiDialogInfo;
//     [SerializeField] PlayerMovement playerMovement;
//     [SerializeField] TextMeshProUGUI MagazineInfo;
//     public bool dialogActive = false;
//     public bool approachActive = false;

//     List<string> einstiegsNPC = new List<string> { "Damn, thought we lost you. We found you out there alone — your squad didn’t make it.",
//                                                    "Wait. What happened to me?", 
//                                                     "No memory, huh? Figures.", 
//                                                     "After those Monsters took ND City, your team was sent to scout a nearby enemy outpost.", 
//                                                     "Mission went to hell.", 
//                                                     "But you’re still breathing ay, and that’s all that matters.", 
//                                                     "Now go south to the dummy and warm up your shooting.", 
//                                                     "The commanders wants to talk to you after that.", 
//                                                     "He´s north east." };
//     int dialogTextIndex;

//     // Start is called before the first frame update
//     void Start()
//     {
//         uiDialogInfo.text = $"";
//         uiDialogInfo.color = Color.green;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (dialogTextIndex == 1)
//         {
//             uiDialogInfo.color = Color.red;
//         }
//         else if (dialogTextIndex == 2)
//         {
//             uiDialogInfo.color = Color.green;
//         }
            
            
//             if (!dialogActive)
//         {
//             playerMovement.playerDialogActive = false;
//         }
//         else if (dialogActive)
//         {
//             playerMovement.playerDialogActive = true;

//             if (Input.GetKeyDown(KeyCode.Space))
//             {
//                 if (dialogTextIndex < (einstiegsNPC.Count - 1))
//                 {   
//                     NextDialogElement();
//                 }
//                 else
//                 {
//                     EndDialog();
//                 }
//             }

//             if (Input.GetKeyDown(KeyCode.Escape))
//             {
//                 EndDialog();
//             }
//         }
//         if (approachActive)
//         {
//             if (Input.GetKeyDown(KeyCode.E))
//             {
//                 StartDialog();
//                 approachActive = false;
//             }
//         }
        
//     }
//     void StartDialog()
//     {
//         dialogActive = true;
//         dialogTextIndex = 0;
//         uiDialogInfo.text = einstiegsNPC[dialogTextIndex];
//         if (MagazineInfo.rectTransform.anchoredPosition != new Vector2(10, 67.5f))
//         {
//             MagazineInfo.rectTransform.anchoredPosition += new Vector2(0, 67.5f);
//         }
//     }

//     void NextDialogElement()
//     {
//         dialogTextIndex += 1;
//         uiDialogInfo.text = EinstiegsNPC[dialogTextIndex];        
//     }

//     void EndDialog()
//     {
//         dialogActive = false;
//         MagazineInfo.rectTransform.anchoredPosition -= new Vector2(0, 67.5f);
//         dialogTextIndex = 0;
//         uiDialogInfo.text = $"";
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI uiDialogInfo;
    [SerializeField] PlayerMovement playerMovement;
    public bool dialogActive = false;
    public bool approachActive = false;

    List<string> dialog = new List<string> { "Du kleiner Go!", "Was los yane", "Du schuldest mir Fuchs du pic", "Geiz nicht so du lümmeltüte"};

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
                Debug.Log("xxx");
                StartDialog();
                approachActive = false;
            }
        }
        
    }
    public void StartDialog()
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