using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonologTrigger : MonoBehaviour
{
    // public PlayerMovement PlayerMovement;
    [SerializeField] DialogManager dialogManager;
    // [SerializeField] TextMeshProUGUI uiDialogInfo;
    // [SerializeField] TextMeshProUGUI MagazineInfo;
    // string MonoLogLvl2 = "Can�t screw this up again... just follow orders.";
    bool alreadyPlayed = false;

    void Start()
    {
        // uiDialogInfo.text = $"";
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     Debug.Log("SpaceBar!");
        //     EndMonolog();
        //     alreadyPlayed = true;
        // }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dialogManager.StartDialog();
            dialogManager.dialogActive = true;
        }
        // if (!alreadyPlayed)
        // {
        //     Debug.Log("Dabei");
        //     StartMonolog();
        // }
    }

    // void StartMonolog()
    // {
    //     uiDialogInfo.text = MonoLogLvl2;
    //     PlayerMovement.playerDialogActive = true;
    //     if (MagazineInfo.rectTransform.anchoredPosition != new Vector2(10, 67.5f))
    //     {
    //         MagazineInfo.rectTransform.anchoredPosition += new Vector2(0, 67.5f);
    //     }

    // }

    // void EndMonolog()
    // {
    //     uiDialogInfo.text = $"";
    //     PlayerMovement.playerDialogActive = false;
    //     MagazineInfo.rectTransform.anchoredPosition -= new Vector2(0, 67.5f);
    // }
}
