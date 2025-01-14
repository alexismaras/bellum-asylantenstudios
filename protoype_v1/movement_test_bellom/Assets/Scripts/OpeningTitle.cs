using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class OpeningTitle : MonoBehaviour
{
    [SerializeField] SceneSwitcher sceneSwitcher;
    [SerializeField] GameObject videoPlayerGameObject;

    VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = videoPlayerGameObject.GetComponent<VideoPlayer>();
        videoPlayer.playOnAwake = false;
        videoPlayer.isLooping = false;
        videoPlayer.Prepare();
        videoPlayer.loopPointReached += OnVideoEnd;
        videoPlayer.prepareCompleted+=PlayVideo;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            InitiateSceneSwitch();
        }
    }

    void PlayVideo(VideoPlayer readyVideoPlayer)
    {
        readyVideoPlayer.Play();
    }

    void OnVideoEnd(VideoPlayer finishedVideoPlayer)
    {
        InitiateSceneSwitch();
    }

    void InitiateSceneSwitch()
    {
        sceneSwitcher.ChangeScene();
    }
}
