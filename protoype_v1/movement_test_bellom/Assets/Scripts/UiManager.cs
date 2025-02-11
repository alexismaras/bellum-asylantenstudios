using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI uiMagazineInfo;

    [SerializeField] TextMeshProUGUI uiGoreMeterInfo;

    [SerializeField] Image uiHealthBar;

    [SerializeField] BulletManager bulletManager;

    [SerializeField] GoreMeter goreMeter;

    [SerializeField] PlayerMovement playerMovement;

    float playerMaxHealth;

    float healthBarMaxPosX;
    float healthBarMinPosX;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 newPosition = uiHealthBar.rectTransform.anchoredPosition;
        healthBarMaxPosX = newPosition.x + (uiHealthBar.rectTransform.rect.width * uiHealthBar.rectTransform.localScale.x * 0.5f);
        healthBarMinPosX = newPosition.x - (uiHealthBar.rectTransform.rect.width * uiHealthBar.rectTransform.localScale.x * 0.5f);
        playerMaxHealth = playerMovement.health;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newScale = uiHealthBar.rectTransform.localScale;
        newScale.x = (playerMovement.health/playerMaxHealth);
        uiHealthBar.rectTransform.localScale = newScale;

        Vector2 newPosition = uiHealthBar.rectTransform.anchoredPosition;
        newPosition.x = (healthBarMinPosX + (uiHealthBar.rectTransform.rect.width * uiHealthBar.rectTransform.localScale.x * 0.5f));
        uiHealthBar.rectTransform.anchoredPosition = newPosition;

        Debug.Log(newPosition);

        uiMagazineInfo.text = $"{bulletManager.magazineFill}/{bulletManager.ammoReserve}";
        if (goreMeter.goreMeterActive)
        {
            uiGoreMeterInfo.text = $"Gore: {goreMeter.goreMeterScore}%";
        }
    }
}
