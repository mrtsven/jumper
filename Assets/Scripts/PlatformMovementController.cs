using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementController : MonoBehaviour
{
    public float speed = 1;
    public float forwardFromOrigin;
    public float backwardsFromOrigin;

    private float direction = 1;
    private float originPosition;

    void Start(){
        originPosition = transform.position.z;
    }

    private void OnCollisionEnter(Collision collision){
        var player = collision.collider.transform.parent;

        if(player.tag == "Player"){
            player.transform.SetParent(transform);
        }
     }
 
    private void OnCollisionExit(Collision collision){
        var player = collision.collider.transform.parent;

        if(player.tag == "Player"){
            player.transform.SetParent(null);
        }
     }    

    void Update()
    {
        if(transform.position.z > originPosition + forwardFromOrigin)
        {            
            direction = -1;
        } else if(transform.position.z < originPosition + backwardsFromOrigin)
        {
            direction = 1;
        }

        transform.position = transform.position + Vector3.forward * direction * speed * Time.deltaTime;
    }
}
