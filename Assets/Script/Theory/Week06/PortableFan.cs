using UnityEngine;

public class PortableFan : ISwitchControl
{
    public bool isOn { get => _isOn; set => _isOn = value; } //short ver
    public bool _isOn = false;

    int currentNumber = 0;
    int MaxNumber = 3;

    public void TurnOff()
    {
        _isOn = false;
        currentNumber = 0;
        Debug.Log("Motor turned OFF.");

    }

    public void TurnOn()
    {
        currentNumber++;
        if (currentNumber > MaxNumber)
        {
            currentNumber = 1;
        }
        if (currentNumber == 1)
        {
            Debug.Log("Motor turned ON : Low speed");

        }
        else if (currentNumber == 2)
        {
            Debug.Log("Motor turned ON : Middle speed");
        }
        else if (currentNumber == 3)
        {
            Debug.Log("Motor turned ON : High speed");
        }
    }
}
