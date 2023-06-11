using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatchCanvasController : MonoBehaviour
{
    public GameObject canvas;
    public GameObject leftHand;

    public GameObject screen1;
    public GameObject screen2;
    public float minTilt; // ���� ���� �ּҰ�
    public float maxTilt; // ���� ���� �ִ밪

    void Start()
    {
        canvas.SetActive(false);
        screen2.SetActive(false);
    }

    void Update()
    {
        // ���⸦ �����ؼ� UI Ȱ��ȭ
        float handTilt = leftHand.transform.eulerAngles.z;

        if (handTilt >= minTilt && handTilt <= maxTilt)
        {
            canvas.SetActive(true);
            screen1.SetActive(false);
            screen2.SetActive(true);
        }
        else
        {
            canvas.SetActive(false);
            screen1.SetActive(true);
            screen2.SetActive(false);
        }
    }
}
