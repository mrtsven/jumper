using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    public float rotationSpeed = 1;
    public float jumpForce = 1;
    //Bullet
    public GameObject Bullet;

    private Rigidbody rb;
    private Vector3 movement;
    private bool isGrounded;
    private Vector3 jump;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0, 2f, 0);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Update()
    {
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 move = (new Vector3(0, 0.0f, moveVertical) * speed * Time.deltaTime).normalized;
        move = transform.TransformDirection(move);

        rb.MovePosition(transform.position + move * speed * Time.deltaTime);

        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Rotate(Vector3.up * -rotationSpeed);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Rotate(Vector3.up * rotationSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        }

        if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if(GameObject.FindGameObjectsWithTag("Bullet").Length < 3)
                ShootBullet();
        } 
        
        checkEndlessfall();
    }

    private void ShootBullet()
    {
        //Shoot the bullet
        Instantiate(Bullet, transform.position + Vector3.forward * 0.5f, transform.rotation);
    }

    private void checkEndlessfall()
    {
        if(transform.position.y < -25)
        {
            SceneManager.LoadScene(0);
        }
    }
}
