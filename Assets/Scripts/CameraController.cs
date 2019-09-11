using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    private Vector3 offset;
    private MovementController movement;

    void Start ()
    {
        movement = player.GetComponent("MovementController") as MovementController;
        offset = transform.position - player.position;
    }

    void LateUpdate ()
    {
        offset = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * movement.speed / 2 , Vector3.up) * offset;
        transform.position = player.position + offset; 
        transform.LookAt(player.position);
    }
}
