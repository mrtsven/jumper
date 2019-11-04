using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBulletController : MonoBehaviour
{
    public float Speed = 300.0f;
    public float LifeTime = 1f;
    public int damage = 1;

    void Start()
    {
        Destroy(gameObject, LifeTime);
    }

    void Update()
    {
        transform.position += 
			transform.forward * Speed * Time.deltaTime;       
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
            Destroy(gameObject);
    }
}
