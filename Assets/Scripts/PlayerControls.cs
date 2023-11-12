using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D rb { get { if (!_rb) _rb = GetComponent<Rigidbody2D>(); return _rb; } }
    private Rigidbody2D _rb;
    public float moveSpeed = 6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!rb)
            return;

        Vector3 move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (move.sqrMagnitude > 1)
            move = move.normalized;
        rb.velocity = move * moveSpeed;
        rb.SetRotation(0);
    }
}
