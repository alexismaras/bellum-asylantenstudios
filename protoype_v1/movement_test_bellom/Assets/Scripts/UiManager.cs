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

    [SerializeField] Image uiHealthFrame;

    [SerializeField] Image uiBossHealthBar;
    [SerializeField] Image uiBossHealthFrame;

    [SerializeField] BulletManager bulletManager;

    [SerializeField] GoreMeter goreMeter;

    [SerializeField] PlayerMovement playerMovement;

    [SerializeField] GoreNPC boss;

    [SerializeField] bool bossLevel;

    float playerMaxHealth;
    float healthBarMaxPosX;
    float healthBarMinPosX;

    float bossMaxHealth;
    float bossHealthBarMaxPosX;
    float bossHealthBarMinPosX;
    // Start is called before the first frame update
    void Start()
    {
        if (bossLevel)
        {
            uiBossHealthBar.gameObject.SetActive(true);
            uiBossHealthFrame.gameObject.SetActive(true);

            uiBossHealthBar.rectTransform.anchorMin = new Vector2(0.5f, 1f);
            uiBossHealthBar.rectTransform.anchorMax = new Vector2(0.5f, 1f);
            uiBossHealthBar.rectTransform.pivot = new Vector2(0.5f, 0.5f);
            uiBossHealthBar.rectTransform.anchoredPosition = new Vector2(0f, -30);

            uiBossHealthFrame.rectTransform.anchorMin = new Vector2(0.5f, 1f);
            uiBossHealthFrame.rectTransform.anchorMax = new Vector2(0.5f, 1f);
            uiBossHealthFrame.rectTransform.pivot = new Vector2(0.5f, 0.5f);
            uiBossHealthFrame.rectTransform.anchoredPosition = new Vector2(0f, -30);

            Vector2 newBossHealthBarPosition = uiBossHealthBar.rectTransform.anchoredPosition;

            bossHealthBarMaxPosX = newBossHealthBarPosition.x + (uiBossHealthBar.rectTransform.rect.width * uiBossHealthBar.rectTransform.localScale.x * 0.5f);
            bossHealthBarMinPosX = newBossHealthBarPosition.x - (uiBossHealthBar.rectTransform.rect.width * uiBossHealthBar.rectTransform.localScale.x * 0.5f);
            bossMaxHealth = boss.health;
        }

        else
        {
            uiBossHealthBar.gameObject.SetActive(false);
            uiBossHealthFrame.gameObject.SetActive(false);
        }

        uiHealthBar.rectTransform.anchorMin = new Vector2(1f, 0f);
        uiHealthBar.rectTransform.anchorMax = new Vector2(1f, 0f);
        uiHealthBar.rectTransform.pivot = new Vector2(0.5f, 0.5f);
        uiHealthBar.rectTransform.anchoredPosition = new Vector2(-80f, 30f);

        uiHealthFrame.rectTransform.anchorMin = new Vector2(1f, 0f);
        uiHealthFrame.rectTransform.anchorMax = new Vector2(1f, 0f);
        uiHealthFrame.rectTransform.pivot = new Vector2(0.5f, 0.5f);
        uiHealthFrame.rectTransform.anchoredPosition = new Vector2(-80f, 30f);

        Vector2 newHealthBarPosition = uiHealthBar.rectTransform.anchoredPosition;

        healthBarMaxPosX = newHealthBarPosition.x + (uiHealthBar.rectTransform.rect.width * uiHealthBar.rectTransform.localScale.x * 0.5f);
        healthBarMinPosX = newHealthBarPosition.x - (uiHealthBar.rectTransform.rect.width * uiHealthBar.rectTransform.localScale.x * 0.5f);

        Debug.Log($"{uiHealthBar.rectTransform.rect.width}; {healthBarMaxPosX}; {healthBarMinPosX}; {playerMaxHealth}");

        playerMaxHealth = playerMovement.health;

        
    }

    // Update is called once per frame
    void Update()
    {
        uiHealthBar.rectTransform.anchorMin = new Vector2(1f, 0f);
        uiHealthBar.rectTransform.anchorMax = new Vector2(1f, 0f);
        uiHealthBar.rectTransform.pivot = new Vector2(0.5f, 0.5f);
        uiHealthBar.rectTransform.anchoredPosition = new Vector2(-80f, 30f);

        uiHealthFrame.rectTransform.anchorMin = new Vector2(1f, 0f);
        uiHealthFrame.rectTransform.anchorMax = new Vector2(1f, 0f);
        uiHealthFrame.rectTransform.pivot = new Vector2(0.5f, 0.5f);
        uiHealthFrame.rectTransform.anchoredPosition = new Vector2(-80f, 30f);

        Debug.Log($"{healthBarMaxPosX}; {healthBarMinPosX}; {playerMaxHealth}");

        Vector3 newHealthBarScale = uiHealthBar.rectTransform.localScale;
        newHealthBarScale.x = (playerMovement.health/playerMaxHealth);
        uiHealthBar.rectTransform.localScale = newHealthBarScale;

        Vector2 newHealthBarPosition = uiHealthBar.rectTransform.anchoredPosition;
        newHealthBarPosition.x = (healthBarMinPosX + (uiHealthBar.rectTransform.rect.width * uiHealthBar.rectTransform.localScale.x * 0.5f));
        uiHealthBar.rectTransform.anchoredPosition = newHealthBarPosition;

        if (bossLevel)
        {
            uiBossHealthBar.rectTransform.anchorMin = new Vector2(0.5f, 1f);
            uiBossHealthBar.rectTransform.anchorMax = new Vector2(0.5f, 1f);
            uiBossHealthBar.rectTransform.pivot = new Vector2(0.5f, 0.5f);
            uiBossHealthBar.rectTransform.anchoredPosition = new Vector2(0f, -30);

            uiBossHealthFrame.rectTransform.anchorMin = new Vector2(0.5f, 1f);
            uiBossHealthFrame.rectTransform.anchorMax = new Vector2(0.5f, 1f);
            uiBossHealthFrame.rectTransform.pivot = new Vector2(0.5f, 0.5f);
            uiBossHealthFrame.rectTransform.anchoredPosition = new Vector2(0f, -30);

            Debug.Log($"{bossHealthBarMaxPosX}; {bossHealthBarMinPosX}; {bossMaxHealth}");

            Vector3 newBossHealthBarScale = uiBossHealthBar.rectTransform.localScale;
            newBossHealthBarScale.x = (boss.health/bossMaxHealth);
            uiBossHealthBar.rectTransform.localScale = newBossHealthBarScale;

            Vector2 newBossHealthBarPosition = uiBossHealthBar.rectTransform.anchoredPosition;
            newBossHealthBarPosition.x = (bossHealthBarMinPosX + (uiBossHealthBar.rectTransform.rect.width * uiBossHealthBar.rectTransform.localScale.x * 0.5f));
            uiBossHealthBar.rectTransform.anchoredPosition = newBossHealthBarPosition;
        }

        uiMagazineInfo.text = $"{bulletManager.magazineFill}/{bulletManager.ammoReserve}";
        if (goreMeter.goreMeterActive)
        {
            uiGoreMeterInfo.text = $"Gore: {goreMeter.goreMeterScore}%";
        }
    }
}
