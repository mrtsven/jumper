using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 5f;  // Detection range for player
    public float health = 3f;
    public float inversionTime = 3f;

    private float timer = 0.0f;

    public GameObject inversionField;
    private bool inversionFieldActive = false;
    private GameObject field;

    Transform target;   // Reference to the player
    UnityEngine.AI.NavMeshAgent agent; // Reference to the NavMeshAgent
    Rigidbody rb;

    public StopDistanceSO stopDistanceConfig;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.stoppingDistance = stopDistanceConfig.stoppingDistance;
    }

    // Update is called once per frame
    void Update()
    {
        // Distance to the target
        float distance = Vector3.Distance(target.position, transform.position);

        // If inside the lookRadius
        if (distance <= lookRadius)
        {
            // If within attacking distance
            if (distance <= agent.stoppingDistance)
            {
                // Attack the target
                FaceTarget();   // Make sure to face towards the target

                createInversionField();

            }
            else
            {
                // Move towards the target
                agent.SetDestination(target.position);
            }
        }

        CheckDeath();
    }

    // Rotate to face the target
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            rb.AddForce(Vector3.back * 3, ForceMode.Impulse);
            health -= 1;
        }
    }

    void CheckDeath()
    {
        if (health <= 0)
            Destroy(gameObject);
    }

    void createInversionField()
    {
        if (!inversionFieldActive)
        {
            inversionFieldActive = true;
            timer = 0f;
            field = Instantiate(inversionField, target.position + Vector3.up * 2, target.rotation);
        }
        else if (timer >= inversionTime)
        {
            inversionFieldActive = false;
            Destroy(field);
        }

        timer += Time.deltaTime;

    }

}
