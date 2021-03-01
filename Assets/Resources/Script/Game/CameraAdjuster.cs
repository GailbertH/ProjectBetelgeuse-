using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjuster : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sizeTracker;


    void Start()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        Debug.Log(Screen.width + " " + Screen.height);
        float targetRatio = sizeTracker.bounds.size.x / sizeTracker.bounds.size.y;
        Debug.Log(screenRatio + " " + targetRatio);
        if (screenRatio > targetRatio)
        {
            Camera.main.orthographicSize = sizeTracker.bounds.size.y / 2;
            Debug.Log(sizeTracker.bounds.size.y / 2);
        }
        else
        {
            float diff = targetRatio/ screenRatio;
            Camera.main.orthographicSize = sizeTracker.bounds.size.y / 2 * diff;
            Debug.Log(sizeTracker.bounds.size.y / 2 * diff);
        }
    }
}
