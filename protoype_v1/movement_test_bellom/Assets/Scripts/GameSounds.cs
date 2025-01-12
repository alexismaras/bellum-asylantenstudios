using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSounds : MonoBehaviour
{
    [SerializeField]
    AudioSource hitmarker;

    [SerializeField]
    AudioSource gunshot;    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayHitmarker()
    {
        hitmarker.Play();
    }

    public void PlayGunshot()
    {
        gunshot.Play();
    }
}

