using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUpAndDrop : MonoBehaviour
{
    public LayerMask mask;
    public Transform thisKeyHole;
    // Start is called before the first frame update
    void Start()
    {

    }
    private float cooldown = 0;
    // Update is called once per frame
    void Update()
    {
        cooldown = Mathf.Max(0, cooldown - Time.deltaTime);
        if (cooldown > 0 || thisKeyHole == null || !Input.GetButtonDown("Jump"))
            return;

        Collider2D collider = Physics2D.OverlapBox(transform.position, Vector2.one, 0, mask);
        if (collider == null || collider.gameObject.tag != "KeyHole")
            return;

        Key thisKey = thisKeyHole.GetComponentInChildren<Key>();
        Key otherKey = collider.gameObject.GetComponentInChildren<Key>();
        Transform otherKeyHole = collider.gameObject.transform;

        if (thisKey == null && otherKey != null)
        {
            otherKey.transform.parent = thisKeyHole;
            otherKey.transform.position = thisKeyHole.position;
            otherKey.transform.rotation = thisKeyHole.rotation;
            cooldown = 0.5f;
        }

        if (thisKey != null && otherKey == null)
        {
            thisKey.transform.parent = otherKeyHole;
            thisKey.transform.position = otherKeyHole.position;
            thisKey.transform.rotation = otherKeyHole.rotation;
            cooldown = 0.5f;
        }

    }
}
