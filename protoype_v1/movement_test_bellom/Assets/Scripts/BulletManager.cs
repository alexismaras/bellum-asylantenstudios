using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletManager : MonoBehaviour
{
    [SerializeField]
    GameSounds gameSounds;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    MuzzleFlashFX muzzleFlashFx;

    public bool shooting;
    bool performing;

    public int magazineSize;
    public int magazineFill;
    public int ammoReserve;

    [SerializeField]
    float initialShootingInterval;
    public float shootingInterval;

    [SerializeField]
    float initialBulletSpeed;
    public float bulletSpeed;

    [SerializeField]
    float initialVolume;
    public float volume;

    float previousGoremeterMultiplier;
    public float goreMeterMultiplier;

    [SerializeField]
    float muzzleFlashTime;

    // Start is called before the first frame update
    void Start()
    {
        shooting = false;
        performing = false;
        previousGoremeterMultiplier = goreMeterMultiplier;
        volume = initialVolume;
        bulletSpeed = initialBulletSpeed;
        shootingInterval = initialShootingInterval;
    }
    void Update()
    {
        MagazineReload();


    }

    void FixedUpdate()
    {
        if (shooting == true && performing == false && magazineFill > 0)
        {
            magazineFill -= 1;
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
        volume = (initialVolume+(initialVolume*goreMeterMultiplier));
    }
    void RaiseBulletSpeedByGoremeter()
    {
        bulletSpeed = (initialBulletSpeed+(initialBulletSpeed*goreMeterMultiplier));
    }

    void RaiseShootingIntervalByGoremeter()
    {
        shootingInterval = (shootingInterval-(shootingInterval*goreMeterMultiplier));
    }

    IEnumerator BulletInstantiate()
    {
        performing = true;
        gameSounds.PlayGunshot();
        GameObject bullet_instance = GameObject.Instantiate(bullet) as GameObject;
        bullet_instance.tag = "ProjectileInstance";
        yield return new WaitForSeconds(shootingInterval);
        performing = false;
    }
    IEnumerator ShowMuzzleFlashFX()
    {
        muzzleFlashFx.EnableRenderer();
        yield return new WaitForSeconds(muzzleFlashTime);
        muzzleFlashFx.DisableRenderer();
    }

    void MagazineReload()
    {
        if (magazineFill < magazineSize && Input.GetKeyDown(KeyCode.R))
        {
            if (ammoReserve >= magazineSize)
            {
                ammoReserve = ammoReserve - (magazineSize - magazineFill);
                magazineFill = magazineSize;
            }
            else if (ammoReserve < magazineSize && ammoReserve > 0)
            {   
                if (ammoReserve >= (magazineSize - magazineFill))
                {
                    ammoReserve = ammoReserve - (magazineSize - magazineFill);
                    magazineFill += magazineSize - magazineFill;
                }
                else if (ammoReserve < (magazineSize - magazineFill))
                {
                    magazineFill += ammoReserve;
                    ammoReserve = 0;
                }
                
            }
        }
        
    }
}
