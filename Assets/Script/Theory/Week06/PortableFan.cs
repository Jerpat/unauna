using System;
using UnityEngine;

public class PortableFan : ISwitchControl
{
    bool _isOn;
    int currentNumber;
    int MaxNumber = 3;
    public bool isOn
    {
        get { return _isOn; }
        set { _isOn = value; }
    }
    public bool IsPoweredOn()
    {
        return _isOn;
    }

    public void TurnOff()
    {
        _isOn = false;
        currentNumber = 0;
        Debug.Log("Motor turned OFF. propeller stopped.");
    }

    public void TurnOn()
    {
        currentNumber++;
        if (currentNumber > MaxNumber)
        {
            currentNumber = 0;
        }

        if (currentNumber == 0)
        {
            TurnOff();
        }
        else if (currentNumber == 1)
        {
            Debug.Log("Motor turned ON. propeller Low / Speed 1.");
        }
        else if (currentNumber == 2)
        {
            Debug.Log("Motor turned ON. propeller Medium / Speed 2.");
        }
        else if (currentNumber == 3)
        {
            Debug.Log("Motor turned ON. propeller High / Speed 3.");
        }
    }
}
