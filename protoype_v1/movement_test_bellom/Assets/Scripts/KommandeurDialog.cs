using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KommandeurDialog : MonoBehaviour
{
    int KommandeurDialogIndex = 0;
    List<string> KommandeurNPC = new List<string> { "Took your damn time waking up.",
                                                    "You know what it cost us to drag your sorry ass back? Two squads. Two full squads. Gone." ,
                                                    "All because your team couldn’t handle one damn mission." ,
                                                    "And now, those bastards are gearing up to hit us first." ,
                                                    "But there’s still a way to prove your worth." ,
                                                    "The enemy is not like us. They are filth, corruption—an infection on our land." ,
                                                    "We are soldiers of the Holy Motherland. We cleanse. We purge. We do what must be done." ,
                                                    "Now get out there. Kill them all. Show them what righteousness looks like.",
                                                    "And if you fail this time, no one’s coming to save you.",
                                                    "Now follow the path on the right. You are already late."};
    [SerializeField] TextMeshProUGUI uiDialogInfo;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] TextMeshProUGUI MagazineInfo;
    [SerializeField] DialogManager dialogManager;
    bool Talkable = false;
    bool inDialog = false;
    [SerializeField] Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        if (playerMovement == null)
        {
            playerMovement = FindObjectOfType<PlayerMovement>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Talkable == true)
        {
            StartDialogKommandeur();
        }

        if (inDialog)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (KommandeurDialogIndex < KommandeurNPC.Count - 1 )
                {
                    NextDialogElementKommandeur();
                }
                else
                {
                    EndDialogKommandeur();
                }
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                EndDialogKommandeur();
            }
        }
        Debug.Log(playerMovement.playerDialogActive);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Collision!");
        if (collision.CompareTag("Player"))
        {
            Talkable = true;
        }
    }
    void StartDialogKommandeur()
    {
        inDialog = true;
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        KommandeurDialogIndex = 0;
        uiDialogInfo.text = KommandeurNPC[KommandeurDialogIndex];
        if (MagazineInfo.rectTransform.anchoredPosition != new Vector2(10, 67.5f))
        {
            MagazineInfo.rectTransform.anchoredPosition += new Vector2(0, 67.5f);
        }
    }
    void NextDialogElementKommandeur()
    {
        KommandeurDialogIndex += 1;
        uiDialogInfo.text = KommandeurNPC[KommandeurDialogIndex];
    }
    void EndDialogKommandeur()
    {
        inDialog = false;
        rb.constraints = RigidbodyConstraints2D.None;
        MagazineInfo.rectTransform.anchoredPosition -= new Vector2(0, 67.5f);
        KommandeurDialogIndex = 0;
        uiDialogInfo.text = $"";
    }
}
