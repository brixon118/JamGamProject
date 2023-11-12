using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingEnemy : MonoBehaviour
{
    [SerializeField] private float startAngle;
    [SerializeField] private float endAngle;

    [SerializeField] private bool clockwise;

    [SerializeField] private float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startAngle == endAngle) transform.Rotate(0, 0, clockwise ? -Mathf.Abs(rotationSpeed) : Mathf.Abs(rotationSpeed));
        else
        {

        }
    }
}
