using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    public float startTime;
    public float moveRange;
    public float moveSpeed = 1f;

    private int direction = 1;
    private float initialX;

    // Start is called before the first frame update
    void Start()
    {
        initialX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Mathf.PingPong((Time.time - startTime) * moveSpeed, moveRange) - (moveRange / 2f);
        transform.position = new Vector3(initialX + distance, transform.position.y, transform.position.z);
    }
}
