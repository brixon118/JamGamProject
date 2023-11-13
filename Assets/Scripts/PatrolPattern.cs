using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPattern : MonoBehaviour
{
    private Rigidbody2D rb { get { if (!_rb) _rb = GetComponent<Rigidbody2D>(); return _rb; } }
    private Rigidbody2D _rb;
    [SerializeField] private float moveSpeed = 6;
    [SerializeField] private GameObject[] patrolPoints;
    private int patrolIndex = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!rb || patrolPoints == null || patrolPoints.Length == 0)
            return;
        Vector2 direction = patrolPoints[patrolIndex].transform.position - transform.position;
        if (direction.sqrMagnitude < 1)
        {
            patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
            direction = patrolPoints[patrolIndex].transform.position - transform.position;
        }

        rb.velocity = direction.normalized * moveSpeed;
        rb.SetRotation(Vector2.SignedAngle(Vector2.right, direction));
    }

    public void StopVelocity()
    {
        if (!rb)
            return;
        rb.velocity = Vector2.zero;
    }

}
