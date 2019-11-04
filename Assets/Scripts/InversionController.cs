using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InversionController : MonoBehaviour
{
    private float pullForce = 200;

    private Rigidbody playerBody;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Entered");
            playerBody = collision.gameObject.GetComponent<Rigidbody>();
        }
    }

    private void OnTriggerStay(Collider collider) {
        if(collider.CompareTag("Player"))
        {
            playerBody.AddForce(Vector3.up * pullForce * Time.fixedDeltaTime, ForceMode.Impulse);
        }
    }
}
