using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelTrigger : MonoBehaviour
{

    [SerializeField] SceneSwitcher sceneSwitcher;

    public bool isAvailable = false;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isAvailable)
        {
            sceneSwitcher.ChangeScene();
        }
    }

}