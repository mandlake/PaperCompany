using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 0, 0.4f, Space.World);
    }
}
