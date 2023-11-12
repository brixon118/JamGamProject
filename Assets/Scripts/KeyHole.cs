using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyHole : MonoBehaviour
{

    public UnityEvent unlockEvent;
    public UnityEvent lockEvent;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentInChildren<Key>())
            unlockEvent.Invoke();
        else
            lockEvent.Invoke();
    }
}
