using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKey : MonoBehaviour
{
    public LayerMask mask;
    private float cooldown = 0;
    // Update is called once per frame
    void Update()
    {
        cooldown = Mathf.Max(0, cooldown - Time.deltaTime);
        if (cooldown > 0 || !Input.GetButtonDown("Jump"))
            return;

        Collider2D collider = Physics2D.OverlapBox(transform.position, Vector2.one, 0, mask);
        if (collider == null)
            return;
        
        Switch otherSwitch = collider.gameObject.GetComponentInChildren<Switch>();
        if (!otherSwitch)
            return;

        otherSwitch.FlipSwitch();
        cooldown = 0.5f;

    }
}
