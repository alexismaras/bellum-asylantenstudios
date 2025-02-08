using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonologTrigger : MonoBehaviour
{
    [SerializeField] DialogManager dialogManager;


    void Start()
    {
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<Collider2D>().enabled = false;
            dialogManager.StartDialog();
            dialogManager.dialogActive = true;
        } 
    }
}