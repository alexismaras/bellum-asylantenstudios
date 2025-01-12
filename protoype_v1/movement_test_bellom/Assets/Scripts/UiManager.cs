using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI uiMagazineInfo;

    [SerializeField]
    TextMeshProUGUI uiGoreMeterInfo;

    [SerializeField]
    BulletManager bulletManager;

    [SerializeField]
    GoreMeter goreMeter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        uiMagazineInfo.text = $"{bulletManager.magazineFill}/{bulletManager.ammoReserve}";
        if (goreMeter.goreMeterActive)
        {
            uiGoreMeterInfo.text = $"Gore: {goreMeter.goreMeterScore}%";
        }
    }
}
