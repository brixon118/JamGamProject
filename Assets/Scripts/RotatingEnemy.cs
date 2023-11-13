using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingEnemy : MonoBehaviour
{
    [SerializeField] private float startAngle;
    [SerializeField] private float endAngle;

    [SerializeField] private float rotationTime;

    [SerializeField] private float pauseTime;

    private Vector3 startTarget;
    private Vector3 endTarget;

    private float rotation;
    private bool paused;

    // Start is called before the first frame update
    void Start()
    {
        startTarget = Vector3.right * Mathf.Cos(startAngle * Mathf.Deg2Rad) + Vector3.up * Mathf.Sin(startAngle * Mathf.Deg2Rad);
        endTarget = Vector3.right * Mathf.Cos(endAngle * Mathf.Deg2Rad) + Vector3.up * Mathf.Sin(endAngle * Mathf.Deg2Rad);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, startTarget);
    }

    // Update is called once per frame
    void Update()
    {
        rotation += Time.deltaTime;
        if (paused)
        {
            if (rotation >= pauseTime)
            {
                rotation = 0;
                paused = false;
            }
            return;
        }
        if (rotation < rotationTime)
        {
            transform.rotation = Quaternion.Slerp(Quaternion.LookRotation(Vector3.forward, startTarget), Quaternion.LookRotation(Vector3.forward, endTarget), rotation / rotationTime);
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, endTarget);
            Vector3 t = startTarget;
            startTarget = endTarget;
            endTarget = t;
            rotation = 0;
            paused = true;
        }
    }
}
