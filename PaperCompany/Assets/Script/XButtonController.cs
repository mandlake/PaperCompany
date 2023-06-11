using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class XButtonController : MonoBehaviour
{
    public InputActionProperty A;

    private void Toggle()
    {
        Debug.Log("toggle");
    }

    private void Update()
    {
        if(A.action.WasPressedThisFrame())
        {
            Toggle();
        }
    }
}
