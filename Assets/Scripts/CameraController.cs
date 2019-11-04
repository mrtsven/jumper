using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    private Vector3 offset;
    private PlayerController movement;

    void Start ()
    {
        movement = player.GetComponent("PlayerController") as PlayerController;
        offset = transform.position - player.position;
    }

    void LateUpdate ()
    {
        offset = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * movement.speed / 2 , Vector3.up) * offset;
        transform.position = player.position + offset; 
        transform.LookAt(player.position);
    }
}
