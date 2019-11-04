using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitController : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider) {
        if(collider.CompareTag("Player"))
        {
            collider.GetComponent<Collider>().enabled = false;
        }
    }
}
