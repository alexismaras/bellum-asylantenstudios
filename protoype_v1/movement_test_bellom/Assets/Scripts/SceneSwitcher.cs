using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] int nextScene;
    // public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (Player.CompareTag("Player"))
    //     {
    //         SceneManager.LoadScene(2);
    //     }
    // }
    // public void ChangeScene()
    // {
    //     next_scene += 1;
    //     SceneManager.LoadScene(2);
    // }

    public void ChangeScene()
    {  
        SceneManager.LoadScene(nextScene);

    }
}
