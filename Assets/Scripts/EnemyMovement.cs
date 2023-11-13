using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] patrolPoints;

    [SerializeField] private float movementSpeed;

    [SerializeField] private float rotationTime;

    private Rigidbody2D rb;

    private int currentPatrolPoint;

    private Quaternion startRotation;
    private Quaternion endRotation;

    private float rotation;
    private bool rotating;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (rotating)
        {
            rotation += Time.deltaTime;
            if (rotation < rotationTime)
            {
                transform.rotation = Quaternion.Slerp(startRotation, endRotation, rotation / rotationTime);
            }
            else
            {
                transform.rotation = endRotation;
                rotation = 0;
                rotating = false;
            }
            return;
        }
        Vector3 patrolPoint = patrolPoints[currentPatrolPoint].transform.position;
        Vector2 patrolPoint2D = new Vector2(patrolPoint.x, patrolPoint.y);
        rb.MovePosition(rb.position + (patrolPoint2D - rb.position).normalized * movementSpeed * Time.deltaTime);
        if (Vector2.Distance(rb.position, patrolPoint2D) <= 0.1f)
        {
            currentPatrolPoint = (currentPatrolPoint + 1) % patrolPoints.Length;
            startRotation = endRotation;
            endRotation = Quaternion.LookRotation(Vector3.forward, patrolPoints[currentPatrolPoint].transform.position - transform.position);
            rotating = true;
        }
    }
}
