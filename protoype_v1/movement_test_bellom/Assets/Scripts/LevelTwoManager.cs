using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GoreNPC shootableNpc1;
    [SerializeField] GoreNPC shootableNpc2;
    [SerializeField] GoreNPC shootableNpc3;
    [SerializeField] GoreNPC shootableNpc4;
    [SerializeField] NextLevelTrigger nextLevelTrigger;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shootableNpc1.health <= 0 && shootableNpc1.health <= 0 && shootableNpc3.health <= 0 && shootableNpc4.health <= 0 && !nextLevelTrigger.isAvailable)
        {
            nextLevelTrigger.isAvailable = true;
        }
    }
}
