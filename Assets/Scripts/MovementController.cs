using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed = 1;
    public float rotationSpeed = 1;
    public float jumpForce = 1;

    private Rigidbody rb;
    private Vector3 movement;
    private bool isGrounded;
    private Vector3 jump;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0, 2f, 0);
    }

    void OnCollisionStay(){
        isGrounded = true;
    }

    void Update(){
        Vector3 move = new Vector3(0, 0, Input.GetAxis("Vertical")).normalized;
        move = transform.TransformDirection(move.normalized) * speed * Time.deltaTime;

        rb.MovePosition(transform.position + move);

        if(Input.GetAxis("Horizontal") < 0){
            transform.Rotate(Vector3.up * rotationSpeed);
        }
        if(Input.GetAxis("Horizontal") > 0){
            transform.Rotate(Vector3.up * -rotationSpeed);
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }        
    }
}
