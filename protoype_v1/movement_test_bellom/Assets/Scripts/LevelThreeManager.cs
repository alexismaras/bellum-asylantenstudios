using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelThreeManager : MonoBehaviour
{
    [SerializeField] DialogManager dialogManager;

    [SerializeField] SceneSwitcher sceneSwitcher;
    [SerializeField] GoreNPC boss;
    bool monologStarted = false;

    bool monologAcitve = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (boss.health <= 0 && !monologStarted)
        {
            monologStarted = true;
            StartCoroutine(MonologDelay());
        }

        if (Input.GetKeyDown(KeyCode.Space) && monologAcitve)
        {
            sceneSwitcher.ChangeScene();
        }
    }

    IEnumerator MonologDelay()
    {
        yield return new WaitForSeconds(1);
        dialogManager.dialogIndex = 3;
        dialogManager.StartDialog();
        dialogManager.dialogActive = true;
        monologAcitve = true;
    }
}
