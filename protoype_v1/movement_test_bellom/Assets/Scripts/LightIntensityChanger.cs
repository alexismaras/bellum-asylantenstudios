using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightIntensityChanger : MonoBehaviour
{
    [SerializeField] Animator animator;
    Light2D light2D;
    [SerializeField] float standardIntensity;
    [SerializeField] float movingIntensity;
    // Start is called before the first frame update
    void Start()
    {
        light2D = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("moving") && light2D.intensity != movingIntensity)
        {
            light2D.intensity = movingIntensity;
        }
        else if (!animator.GetBool("moving") && light2D.intensity != standardIntensity)
        {
            light2D.intensity = standardIntensity;
        }
    }
}
