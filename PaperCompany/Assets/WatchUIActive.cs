using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchUIActive : MonoBehaviour
{
    public float tiltThreshold = -90f; // 기울기 감지 임계값
    public GameObject Canvas;   // UI
    public Transform handTransform; // 손의 기울기

    void Start()
    {
        Canvas.SetActive(false);
    }

    void Update()
    {
        float handTilt = handTransform.eulerAngles.z;

        if (handTilt <= tiltThreshold)
        {
            Canvas.SetActive(true);
        }

        else
        {
            Canvas.SetActive(false);
        }
    }
}
