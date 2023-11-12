using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOnTrigger : MonoBehaviour
{
    public string tagToTeleport = "Player";
    public Vector3 placeToTeleportTo = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.tag != tagToTeleport)
            return;
        collision.gameObject.transform.position = placeToTeleportTo;
    }

}
