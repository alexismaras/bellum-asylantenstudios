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

    List<string> EinstiegsNPC = new List<string> { "Damn, thought we lost you. We found you out there alone — your squad didn’t make it.",
                                                   "Wait. What happened to me?", "No memory, huh? Figures.", 
                                                    "After those Monsters took ND City, your team was sent to scout a nearby enemy outpost.", 
                                                    "Mission went to hell.", 
                                                    "But you’re still breathing ay, and that’s all that matters.", 
                                                    "Now go south to the dummy and warm up your shooting.", 
                                                    "The commanders wants to talk to you after that.", 
                                                    "He´s north east." };

    List<string> KommandeurNPC = new List<string> { "Took your damn time waking up.",
                                                    "You know what it cost us to drag your sorry ass back? Two squads. Two full squads. Gone." ,
                                                    "All because your team couldn’t handle one damn mission." ,
                                                    "And now, those bastards are gearing up to hit us first." ,
                                                    "But there’s still a way to prove your worth." ,
                                                    "The enemy is not like us. They are filth, corruption—an infection on our land." ,
                                                    "We are soldiers of the Holy Motherland. We cleanse. We purge. We do what must be done." ,
                                                    "Now get out there. Kill them all. Show them what righteousness looks like.",
                                                    "And if you fail this time, no one’s coming to save you." };

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
                if (dialogTextIndex < (EinstiegsNPC.Count - 1))
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
        uiDialogInfo.text = EinstiegsNPC[dialogTextIndex];   
    }

    void NextDialogElement()
    {
        dialogTextIndex += 1;
        uiDialogInfo.text = EinstiegsNPC[dialogTextIndex];        
    }

    void EndDialog()
    {
        dialogActive = false;
    }
}
