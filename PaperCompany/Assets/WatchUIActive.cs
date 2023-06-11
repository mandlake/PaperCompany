using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchUIActive : MonoBehaviour
{
    public float tiltThreshold = -90f; // ���� ���� �Ӱ谪
    public GameObject Canvas;   // UI
    public Transform handTransform; // ���� ����

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
