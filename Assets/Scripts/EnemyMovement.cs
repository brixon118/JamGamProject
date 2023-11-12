using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] patrolPoints;

    [SerializeField] private float movementSpeed;

    private Rigidbody2D rb;

    private int currentPatrolPoint;

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
        Vector3 patrolPoint = patrolPoints[currentPatrolPoint].transform.position;
        Vector2 patrolPoint2D = new Vector2(patrolPoint.x, patrolPoint.y);
        rb.MovePosition(rb.position + (patrolPoint2D - rb.position).normalized * movementSpeed * Time.deltaTime);
        if (Vector2.Distance(rb.position, patrolPoint2D) <= 0.1f) currentPatrolPoint = (currentPatrolPoint + 1) % patrolPoints.Length;
    }
}
