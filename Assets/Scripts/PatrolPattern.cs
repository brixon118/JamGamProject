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

    [SerializeField] private GameObject rotator;

    [SerializeField] private float rotationTime;

    private EnemyAnimator animator;

    private Vector2 startPosition;
    private Vector2 endPosition;

    private Quaternion startRotation;
    private Quaternion endRotation;

    private float movementTime;

    private float movement;
    private bool rotating;
    private bool deactivated;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<EnemyAnimator>();
        startPosition = rb.position;
        Vector3 patrolPoint = patrolPoints[patrolIndex].transform.position;
        endPosition = new Vector2(patrolPoint.x, patrolPoint.y);
        endRotation = rotator.transform.rotation;
        movementTime = Vector2.Distance(startPosition, endPosition) / moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        /*
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
        */
    }

    void FixedUpdate()
    {
        if (!rb || patrolPoints == null || patrolPoints.Length == 0 || deactivated) return;
        movement += Time.deltaTime;
        if (rotating)
        {
            if (movement < rotationTime)
            {
                rotator.transform.rotation = Quaternion.Slerp(startRotation, endRotation, movement / rotationTime);
                rotator.transform.Rotate(0, 0, 90, Space.World);
            }
            else
            {
                rotator.transform.rotation = endRotation;
                rotator.transform.Rotate(0, 0, 90, Space.World);
                movement = 0;
                rotating = false;
            }
        }
        else if (movement < movementTime) rb.MovePosition(Vector2.Lerp(startPosition, endPosition, movement / movementTime));
        else
        {
            rb.MovePosition(endPosition);
            patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
            startPosition = rb.position;
            Vector3 patrolPoint = patrolPoints[patrolIndex].transform.position;
            endPosition = new Vector2(patrolPoint.x, patrolPoint.y);
            Vector2 move = endPosition - startPosition;
            animator.SetAnimation(move.x == 0 && move.y == 0 ? -1 : Mathf.Abs(move.x) > Mathf.Abs(move.y) ? (move.x < 0 ? 2 : 3) : (move.y < 0 ? 0 : 1));
            movementTime = Vector2.Distance(startPosition, endPosition) / moveSpeed;
            startRotation = endRotation;
            endRotation = Quaternion.LookRotation(Vector3.forward, patrolPoints[patrolIndex].transform.position - transform.position);
            movement = 0;
            rotating = true;
        }
        /*
        Vector3 patrolPoint = patrolPoints[patrolIndex].transform.position;
        Vector2 patrolPoint2D = new Vector2(patrolPoint.x, patrolPoint.y);
        rb.MovePosition(rb.position + (patrolPoint2D - rb.position).normalized * moveSpeed * Time.deltaTime);
        if (Vector2.Distance(rb.position, patrolPoint2D) <= 0.1f)
        {
            patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
            startPosition = rb.position;
            endPosition = new Vector2(patrolPoint.x, patrolPoint.y);
            movementTime = Vector2.Distance(startPosition, endPosition) / moveSpeed;
            startRotation = endRotation;
            endRotation = Quaternion.LookRotation(Vector3.forward, patrolPoints[patrolIndex].transform.position - transform.position);
            rotating = true;
        }
        */
    }

    public void StopVelocity()
    {
        if (!rb)
            return;
        rb.velocity = Vector2.zero;
        deactivated = true;
        gameObject.layer = LayerMask.NameToLayer("Deactivated");
        animator.Stop();
    }
}
