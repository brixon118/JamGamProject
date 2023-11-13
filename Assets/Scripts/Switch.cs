using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{
    public UnityEvent OffEvent;
    public UnityEvent OnEvent;
    public bool state = true;

    public void OnSwitch()
    {
        OnEvent.Invoke();
    }

    public void OffSwitch()
    {
        OffEvent.Invoke();
    }

    public void FlipSwitch()
    {
        state = !state;
        if (state)
            OnSwitch();
        else
            OffSwitch();
    }

}
