using UnityEngine;

public class LightBulb : ISwitchControl
{
    private bool _isOn = false;
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
        Debug.Log("Light bulb turned OFF. It's dark.");
    }

    public void TurnOn()
    {
        _isOn = true;
        Debug.Log("Light bulb turned ON! It's bright.");
    }
}
