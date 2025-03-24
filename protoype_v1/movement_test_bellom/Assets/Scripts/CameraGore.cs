using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGore : MonoBehaviour
{

    float previousGoremeterMultiplier;
    public float goreMeterMultiplier;

    [SerializeField] Camera cameraMain;

    // Start is called before the first frame update
    void Start()
    {
        previousGoremeterMultiplier = goreMeterMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        // Clamp bei 4 Camera Size

        cameraMain.orthographicSize = Mathf.Clamp(cameraMain.orthographicSize, 0, 4);
    }

    private void FixedUpdate()
    {
        // Wenn der aktuelle GoreMeter höher ist, dann erhöhe die CameraSize
        if (previousGoremeterMultiplier != goreMeterMultiplier)
        {
            if (cameraMain.orthographicSize <= 4f)
            {
            RaiseCameraSize();
            previousGoremeterMultiplier = goreMeterMultiplier;
            }
        }
    }

    void RaiseCameraSize()
    {
        cameraMain.orthographicSize = cameraMain.orthographicSize + (cameraMain.orthographicSize * Mathf.Pow(goreMeterMultiplier,4));
    }
}
