using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyBulletManager : MonoBehaviour
{
    [SerializeField] GameSounds gameSounds;

    GameObject parentEnemy;

    GameObject enemyBullet;

    [SerializeField] public bool shooting;
    bool performing;

    // public int magazineSize;
    // public int magazineFill;
    // public int ammoReserve;

    [SerializeField] float shootingInterval;

    public float bulletSpeed;

    public float volume;

    // float previousGoremeterMultiplier;
    // public float goreMeterMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        parentEnemy = transform.parent.gameObject;
        enemyBullet = parentEnemy.GetComponentInChildren<EnemyBulletBehaviour>().gameObject;
        shooting = false;
        performing = false;
    }
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (shooting == true && performing == false)
        {
            StartCoroutine(BulletInstantiate());
        }
        // if (previousGoremeterMultiplier != goreMeterMultiplier)
        // {
        //     // RaiseVolumeByGoremeter();
            // RaiseBulletSpeedByGoremeter();
            // RaiseShootingIntervalByGoremeter();
            // previousGoremeterMultiplier = goreMeterMultiplier;
        // }

        
    }

    // void RaiseVolumeByGoremeter()
    // {
    //     volume = (initialVolume+(initialVolume*goreMeterMultiplier));
    // }
    // void RaiseBulletSpeedByGoremeter()
    // {
    //     bulletSpeed = (initialBulletSpeed+(initialBulletSpeed*goreMeterMultiplier));
    // }

    // void RaiseShootingIntervalByGoremeter()
    // {
    //     shootingInterval = (shootingInterval-(shootingInterval*goreMeterMultiplier));
    // }

    IEnumerator BulletInstantiate()
    {
        performing = true;
        gameSounds.PlayGunshot();
        GameObject enemyBulletInstance = GameObject.Instantiate(enemyBullet) as GameObject;
        enemyBulletInstance.transform.SetParent(parentEnemy.transform);
        enemyBulletInstance.tag = "ProjectileInstance";
        yield return new WaitForSeconds(shootingInterval);
        performing = false;
    }

    // void MagazineReload()
    // {
    //     if (magazineFill < magazineSize && Input.GetKeyDown(KeyCode.R))
    //     {
    //         gameSounds.PlayReload();
            
    //         if (ammoReserve >= magazineSize)
    //         {
    //             ammoReserve = ammoReserve - (magazineSize - magazineFill);
    //             magazineFill = magazineSize;
    //         }
    //         else if (ammoReserve < magazineSize && ammoReserve > 0)
    //         {   
    //             if (ammoReserve >= (magazineSize - magazineFill))
    //             {
    //                 ammoReserve = ammoReserve - (magazineSize - magazineFill);
    //                 magazineFill += magazineSize - magazineFill;
    //             }
    //             else if (ammoReserve < (magazineSize - magazineFill))
    //             {
    //                 magazineFill += ammoReserve;
    //                 ammoReserve = 0;
    //             }
                
    //         }
    //     }
        
    // }
}
