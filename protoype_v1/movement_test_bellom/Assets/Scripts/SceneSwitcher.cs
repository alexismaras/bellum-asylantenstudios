using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] int nextScene;

    [SerializeField] Animator animator;
    // [SerializeField] float fadeDuration = 2f;
    // public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ReloadScene()
    {  
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void ChangeScene()
    {  
        animator.SetTrigger("FadeOut");
    }

    // IEnumerator FadeOutCoroutine()
    // {
    //     // float startVolume = menuTheme.volume;
    //     float timer = 0f;

    //     while (timer < fadeDuration)
    //     {
    //         timer += Time.deltaTime;
    //         // menuTheme.volume = Mathf.Lerp(startVolume, 0, timer / fadeDuration);
    //         yield return null;
    //     }

    //     // menuTheme.volume = 0;
    //     // menuTheme.Stop();

    // }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(nextScene);
    }
}
