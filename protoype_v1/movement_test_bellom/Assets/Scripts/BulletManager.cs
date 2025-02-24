using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletManager : MonoBehaviour
{
    [SerializeField] GameSounds gameSounds;

    GameObject parentPlayer;

    GameObject playerBullet;

    [SerializeField] public bool shooting;
    bool performing;

    public int magazineSize;
    public int magazineFill;
    public int ammoReserve;

    [SerializeField] float reloadTime;
    bool isRealoading = false;

    [SerializeField] float initialShootingInterval;
    public float shootingInterval;

    [SerializeField] float initialBulletSpeed;
    public float bulletSpeed;

    [SerializeField] float initialVolume;
    public float volume;

    float previousGoremeterMultiplier;
    public float goreMeterMultiplier;

    [SerializeField] float muzzleFlashTime;

    // Start is called before the first frame update
    void Start()
    {
        parentPlayer = transform.parent.gameObject;
        playerBullet = parentPlayer.GetComponentInChildren<BulletBehaviour>().gameObject;
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
        if (shooting && !isRealoading && !performing && magazineFill > 0)
        {
            magazineFill -= 1;
            StartCoroutine(BulletInstantiate());
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
        shootingInterval = (initialShootingInterval-(initialShootingInterval*goreMeterMultiplier*0.2f));
    }

    IEnumerator BulletInstantiate()
    {
        performing = true;
        gameSounds.PlayGunshot();
        GameObject playerBulletInstance = GameObject.Instantiate(playerBullet) as GameObject;
        playerBulletInstance.transform.SetParent(parentPlayer.transform);
        playerBulletInstance.tag = "ProjectileInstance";
        yield return new WaitForSeconds(shootingInterval);
        performing = false;
    }

    void MagazineReload()
    {
        if (magazineFill < magazineSize && Input.GetKeyDown(KeyCode.R) && !isRealoading)
        {
            gameSounds.PlayReload();
            isRealoading = true;
            StartCoroutine(ReloadDelay());
        }
        
    }

    IEnumerator ReloadDelay()
    {
        yield return new WaitForSeconds(reloadTime);

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

        isRealoading = false;
    }
}
