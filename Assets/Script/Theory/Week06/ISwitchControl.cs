using UnityEngine;

public interface ISwitchControl
{
    bool isOn { get; set; }
    void TurnOn();
    void TurnOff();
    bool IsPoweredOn();
}
