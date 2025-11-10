using UnityEngine;

public interface ITemperatureControl
{
    int TargetTemperature { get; set; }
    int CurrentTemperature { get; }
    int MinTemperature { get; }
    int MaxTemperature { get; }
    void SetTemperature(int degrees);
    int GetCurrentTemperature();
}
