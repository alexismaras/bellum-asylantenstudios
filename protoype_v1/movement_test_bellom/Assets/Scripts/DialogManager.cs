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

    public int dialogIndex;

    List<List<(int, string)>> dialogDict = new   List<List<(int, string)>>();

    List<(int, string)> dialog1 = new List<(int, string)>
    {
        (2, "Damn, thought we lost you. We found you out there alone — your squad didn't make it."),
        (1, "Wait. What happened to me?"),
        (2, "No memory, huh? Figures."),
        (2, "After those Monsters took ND City, your team was sent to scout a nearby enemy outpost."),
        (2, "Mission went to hell."),
        (2, "But you're still breathing, and that's all that matters."),
        (2, "Now go south to the dummy and warm up your shooting."),
        (2, "The commander wants to talk to you after that."),
        (2, "He's northeast.")
    };

    List<(int, string)> dialog2 = new List<(int, string)>
    {
        (2, "Took your damn time waking up."),
        (2, "You know what it cost us to drag your sorry ass back? Two squads. Two full squads. Gone."),
        (2, "All because your team couldn't handle one damn mission."),
        (2, "And now, those bastards are gearing up to hit us first."),
        (2, "But there's still a way to prove your worth."),
        (2, "The enemy is not like us. They are filth, corruption—an infection on our land."),  // Fixed encoding issue
        (2, "We are soldiers of the Holy Motherland. We cleanse. We purge. We do what must be done."),
        (2, "Now get out there. Kill them all. Show them what righteousness looks like."),
        (2, "And if you fail this time, no one's coming to save you."),
        (2, "Now follow the path on the right. You are already late.")
    };

    List<(int, string)> dialog3 = new List<(int, string)>
    {
        ( 1, "Can't screw this up again... just follow orders." ),
        ( 5, "Der Gore Meter: Unsere neueste Erfindung! Das Subjekt wird schneller, stärker und präsiser als jeder andere Soldat! Alles was er dazu tun muss, ist es Feinde auszulöschen." )
    };

    List<(int, string)> dialog4 = new List<(int, string)>
    {
        ( 1, "That was the last one ... I need to report back to the commander." )
    };

    List<(int, string)> dialog5 = new List<(int, string)>
    {
        ( 3, "You slaughtered my people." ),
        ( 3, "My friends." ),
        ( 3, "My family." ),
        ( 3, "And yet" ),
        ( 3, "you call us the monsters." ),
        ( 3, "..." ),
        ( 3, "No one will miss you." )
    };


    int dialogTextIndex;


    // Start is called before the first frame update
    void Start()
    {
        dialogDict.Add(dialog1);
        dialogDict.Add(dialog2);
        dialogDict.Add(dialog3);
        dialogDict.Add(dialog4);
        dialogDict.Add(dialog5);
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
                if (dialogTextIndex < (dialogDict[dialogIndex].Count - 1))
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
        uiDialogInfo.color = GetDialogColor(dialogDict[dialogIndex][dialogTextIndex].Item1);
        uiDialogInfo.rectTransform.anchorMin = GetDialogPosition(dialogDict[dialogIndex][dialogTextIndex].Item1);
        uiDialogInfo.rectTransform.anchorMax = uiDialogInfo.rectTransform.anchorMin;
        uiDialogInfo.rectTransform.pivot = new Vector2(0.5f, 0.5f);
        uiDialogInfo.rectTransform.anchoredPosition = GetDialogPositionOffset(dialogDict[dialogIndex][dialogTextIndex].Item1);
        uiDialogInfo.text = dialogDict[dialogIndex][dialogTextIndex].Item2;
    }

    void NextDialogElement()
    {
        dialogTextIndex += 1;
        uiDialogInfo.color = GetDialogColor(dialogDict[dialogIndex][dialogTextIndex].Item1);
        uiDialogInfo.rectTransform.anchorMin = GetDialogPosition(dialogDict[dialogIndex][dialogTextIndex].Item1);
        uiDialogInfo.rectTransform.anchorMax = uiDialogInfo.rectTransform.anchorMin;
        uiDialogInfo.rectTransform.pivot = new Vector2(0.5f, 0.5f);
        uiDialogInfo.rectTransform.anchoredPosition = GetDialogPositionOffset(dialogDict[dialogIndex][dialogTextIndex].Item1);
        uiDialogInfo.text = dialogDict[dialogIndex][dialogTextIndex].Item2;
    }

    void EndDialog()
    {
        dialogActive = false;
    }

    Color GetDialogColor(int role)
    {
        if (role == 1)
        {
            return Color.red;
        }
        else if (role == 2)
        {
            return Color.green;
        }
        else if (role == 5)
        {
            return Color.white;
        }
        else
        {
            return Color.white;
        }
    }

    Vector2 GetDialogPosition(int role)
    {
        if (role == 1)
        {
            return new Vector2(0.5f, 0f);
        }
        else if (role == 2)
        {
            return new Vector2(0.5f, 0f);
        }
        else if (role == 5)
        {
            return new Vector2(0.5f, 0.5f);
        }
        else
        {
            return new Vector2(0.5f, 0f);
        }
    }

    Vector2 GetDialogPositionOffset(int role)
    {
        if (role == 1)
        {
            return new Vector2(0f, 30f);
        }
        else if (role == 2)
        {
            return new Vector2(0f, 30f);
        }
        else if (role == 5)
        {
            return Vector2.zero;
        }
        else
        {
            return new Vector2(0f, 30f);
        }
    }
}