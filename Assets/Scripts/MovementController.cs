using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed = 1;

    // private Vector3 m_EulerAngleVelocity;

    private Rigidbody rb;
    private Vector3 movement;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update(){
        Vector3 move = new Vector3(0, 0, Input.GetAxis("Vertical")).normalized;
        move = transform.TransformDirection(move.normalized) * speed * Time.deltaTime;

        rb.MovePosition(transform.position + move);

        if(Input.GetAxis("Mouse X") < 0){
            transform.Rotate(Vector3.up * speed / 2);
        }
        if(Input.GetAxis("Mouse X") > 0){
            transform.Rotate(Vector3.up * -speed / 2);
        }
    }
}
