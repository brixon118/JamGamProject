using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EscButton : MonoBehaviour
{
    public UnityEvent OnEscPress; 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            EscInvoke();
    }

    public void EscInvoke()
    {
        OnEscPress.Invoke();
    }

}
