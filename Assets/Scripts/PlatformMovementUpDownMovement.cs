using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementUpDownMovement : MonoBehaviour
{
    public float speed = 1;
    public float forwardFromOrigin;
    public float backwardsFromOrigin;

    private Rigidbody rb;
    private float direction = 1;
    private float originPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > originPosition + forwardFromOrigin)
        {
            direction = -1;
        }
        else if (transform.position.y < originPosition + backwardsFromOrigin)
        {
            direction = 1;
        }

        rb.MovePosition(transform.position + Vector3.up * direction * speed * Time.deltaTime);
    }
}
