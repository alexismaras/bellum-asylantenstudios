using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftPathTriggerScript : MonoBehaviour
{

    [SerializeField] GoreNPC shootableNPC1;
    [SerializeField] GoreNPC shootableNPC2;

    [SerializeField] LevelTwoManager levelTwoManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (shootableNPC1.health <= 0 && shootableNPC2.health <= 0)
        {
            levelTwoManager.activateLeftPathWall = true;
        }
    }
}
