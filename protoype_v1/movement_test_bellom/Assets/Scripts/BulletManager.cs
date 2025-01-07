using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public GameObject bullet;

    public MuzzleFlashFX muzzleFlashFx;

    [Header("Shooting")]
    public bool shooting;
    public bool performing;

    public float shooting_interval;

    public float bullet_speed;

    public float volume;

    [Header("FX")]
    public float muzzleFlashTime;
    // Start is called before the first frame update
    void Start()
    {
        shooting = false;
        performing = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shooting == true && performing == false)
        {
            StartCoroutine(BulletInstantiate());
            StartCoroutine(ShowMuzzleFlashFX());
        }
        
    }
    IEnumerator BulletInstantiate()
    {
        performing = true;
        GameObject bullet_instance = GameObject.Instantiate(bullet) as GameObject;
        bullet_instance.tag = "ProjectileInstance";
        yield return new WaitForSeconds(shooting_interval);
        performing = false;
    }
    IEnumerator ShowMuzzleFlashFX()
    {
        muzzleFlashFx.EnableRenderer();
        yield return new WaitForSeconds(muzzleFlashTime);
        muzzleFlashFx.DisableRenderer();
    }
}
