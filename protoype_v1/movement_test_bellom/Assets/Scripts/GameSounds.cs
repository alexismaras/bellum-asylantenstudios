using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSounds : MonoBehaviour
{

    [SerializeField] Animator playerAnimator;
    [SerializeField] AudioSource hitmarker;

    [SerializeField] AudioSource gunshot;
    [SerializeField] AudioSource reload;

    [SerializeField] AudioSource walking1;
    [SerializeField] AudioSource walking2;
    [SerializeField] AudioSource walking3;

    bool playWalkingAudio = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAnimator.GetBool("moving") && !playWalkingAudio)
        {
            playWalkingAudio = true;
            StartCoroutine(PlayRandomWalking());
        }
    }

    public void PlayHitmarker()
    {
        hitmarker.Play();
    }

    public void PlayGunshot()
    {
        gunshot.Play();
    }

    public void PlayReload()
    {
        reload.Play();
    }

    IEnumerator PlayRandomWalking()
    {
        while (playerAnimator.GetBool("moving"))
        {
            int randomWalkingSound = Random.Range(1,3);

            if (randomWalkingSound == 1)
            {
                walking1.Play();
            }

            else if (randomWalkingSound == 2)
            {
                walking2.Play();
            }

            else if (randomWalkingSound == 3)
            {
                walking3.Play();
            }

            yield return new WaitForSeconds(0.3f);
        }

        playWalkingAudio = false;
    }
}

