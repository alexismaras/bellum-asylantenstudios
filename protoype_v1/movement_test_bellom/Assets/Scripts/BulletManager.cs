using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletManager : MonoBehaviour
{
    public GameObject bullet;

    public MuzzleFlashFX muzzleFlashFx;

    [Header("Shooting")]
    public bool shooting;
    public bool performing;

    public float initial_shooting_interval;
    public float shooting_interval;

    public float initial_bullet_speed;
    public float bullet_speed;

    public float initial_volume;
    public float volume;

    public float previousGoremeterMultiplier;

    [SerializeField]
    public float goreMeterMultiplier;

    [SerializeField]
    public float muzzleFlashTime;
    // Start is called before the first frame update
    void Start()
    {
        shooting = false;
        performing = false;
        previousGoremeterMultiplier = goreMeterMultiplier;
        volume = initial_volume;
        bullet_speed = initial_bullet_speed;
        shooting_interval = initial_shooting_interval;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shooting == true && performing == false)
        {
            StartCoroutine(BulletInstantiate());
            StartCoroutine(ShowMuzzleFlashFX());
        }
        if (previousGoremeterMultiplier != goreMeterMultiplier)
        {
            RaiseVolumeByGoremeter();
            RaiseBulletSpeedByGoremeter();
            RaiseShootingIntervalByGoremeter();
            previousGoremeterMultiplier = goreMeterMultiplier;
        }
        
    }

    void RaiseVolumeByGoremeter()
    {
        volume = (initial_volume+(initial_volume*goreMeterMultiplier));
    }
    void RaiseBulletSpeedByGoremeter()
    {
        bullet_speed = (initial_bullet_speed+(initial_bullet_speed*goreMeterMultiplier));
    }

    void RaiseShootingIntervalByGoremeter()
    {
        shooting_interval = (shooting_interval-(shooting_interval*goreMeterMultiplier));
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
