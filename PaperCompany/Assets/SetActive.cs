using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetActive : MonoBehaviour
{
    public GameObject Layout;
    void Start()
    {
        Layout.SetActive(false);
    }
}
