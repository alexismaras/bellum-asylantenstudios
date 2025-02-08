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

    List<Dictionary<int,string>> dialogDict = new List<Dictionary<int,string>>();

    Dictionary<int,string> dialog1 = new Dictionary<string, int>
    {
        { 2, "Damn, thought we lost you. We found you out there alone — your squad didn't make it." },
        { 1, "Wait. What happened to me?" },
        { 2, "No memory, huh? Figures." }, 
        { 2, "After those Monsters took ND City, your team was sent to scout a nearby enemy outpost." },
        { 2, "Mission went to hell." }, 
        { 2, "But you're still breathing ay, and that's all that matters." }, 
        { 2, "Now go south to the dummy and warm up your shooting." },
        { 2, "The commanders wants to talk to you after that." },
        { 2, "He's north east." }
    };

    Dictionary<string, int> dialog2 = new Dictionary<string, int>
    {
        { 2, "Took your damn time waking up." },
        { 2, "You know what it cost us to drag your sorry ass back? Two squads. Two full squads. Gone."  },
        { 2, "All because your team couldn't handle one damn mission." },
        { 2, "And now, those bastards are gearing up to hit us first." },
        { 2, "But there's still a way to prove your worth." },
        { 2, "The enemy is not like us. They are filth, corruption�an infection on our land." },
        { 2, "We are soldiers of the Holy Motherland. We cleanse. We purge. We do what must be done." },
        { 2, "Now get out there. Kill them all. Show them what righteousness looks like." },
        { 2, "And if you fail this time, no one's coming to save you." },
        { 2, "Now follow the path on the right. You are already late." }
    };

    Dictionary<string, int> dialog3 = new Dictionary<string, int>
        {
        { 1, "Can't screw this up again... just follow orders." };
    };

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