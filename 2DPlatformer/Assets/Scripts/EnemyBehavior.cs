using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 5.0f;
    public float detectionRange = 5.0f;
    private Vector3 target;
    private bool movingToPointA = true;
    private Rigidbody2D rb;
    public Transform player;
    
    
    // Start is called before the first frame update
    void Start()
    {
        target = pointA.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
        MoveTowardsTarget();

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            SwitchTarget();
        }
    }

    void DetectPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRange)
        {
            target = player.position;
        }
        else
        {
            target = movingToPointA ? pointA.position : pointB.position;
        }
    }

    void MoveTowardsTarget()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target);

        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
    }

    void SwitchTarget()
    {
        movingToPointA = !movingToPointA;
        target = movingToPointA ? pointA.position : pointB.position;
    }
}
