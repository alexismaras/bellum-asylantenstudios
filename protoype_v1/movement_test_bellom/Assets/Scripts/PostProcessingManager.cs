using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingManager : MonoBehaviour
{
    Volume volume;
    Vignette vignette;
    [SerializeField] PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        volume = GetComponent<Volume>();
        if (volume.profile.TryGet(out vignette))
        {
            vignette.active = true; // Enable Vignette
            vignette.intensity.Override(0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.playerDialogActive && vignette.intensity.value != 0.3f)
        {
            StartCoroutine(FadeVignette(0.3f, 0.2f));
        }
        else if (!playerMovement.playerDialogActive && vignette.intensity.value != 0f)
        {
            StartCoroutine(FadeVignette(0f, 0.2f));
        }
    }

    IEnumerator FadeVignette(float targetIntensity, float duration)
    {
        float startIntensity = vignette.intensity.value;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float newIntensity = Mathf.Lerp(startIntensity, targetIntensity, elapsedTime / duration);
            vignette.intensity.Override(newIntensity);
            yield return null;
        }

        vignette.intensity.Override(targetIntensity); // Ensure it reaches the exact target
    }
}
