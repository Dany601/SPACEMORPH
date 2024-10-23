using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class MenuToggle : MonoBehaviour
{
    [SerializeField]
    bool initialState;
    [SerializeField]
    UIAnimation uIAnimation;

    bool currentState;
    [SerializeField]
    UnityEvent turnedOn;
    [SerializeField]
    UnityEvent turnedOff;

    public UnityEvent TurnedOn => turnedOn;
    public UnityEvent TurnedOff => turnedOff;

    public void start()
    {
        if (initialState == true)
            TurnOn();
        else
            TurnOff();
    }

    public void ToggleState()
    {
        if (!uIAnimation.IsPaying)
        {
            currentState = !currentState;
            if (currentState == true)
                TurnOn();
            else
                TurnOff();
        }
    }

       

    public void TurnOn()
    {
        if (!uIAnimation.IsPaying)
        {
            currentState = true;
            turnedOn.Invoke();
        }
    }

    public void TurnOff()
    {

        if (!uIAnimation.IsPaying)
        {
            currentState = false;
            turnedOff.Invoke();
        }
    }


}
