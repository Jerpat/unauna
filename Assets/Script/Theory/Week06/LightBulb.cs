using UnityEngine;

public class LightBulb : ISwitchControl
{
    private bool _isOn = false;
    public bool isOn
    {
        get { return _isOn; }
        set { _isOn = value; } // long ver
    }


    public void TurnOff()
    {
        _isOn = false;
        Debug.Log("Lightbulb turned off, it's dark.");
    }

    public void TurnOn()
    {
        _isOn = true;
        Debug.Log("Lightbulb turned on, it's light.");

    }
}
