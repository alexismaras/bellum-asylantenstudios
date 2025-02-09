using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelTrigger : MonoBehaviour
{

    [SerializeField] SceneSwitcher sceneSwitcher;

    [SerializeField] int level;

    public bool isAvailable = false;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isAvailable && level == 1)
        {
            sceneSwitcher.ChangeScene();
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isAvailable && level == 2)
        {
            sceneSwitcher.ChangeScene();
        }
    }

}