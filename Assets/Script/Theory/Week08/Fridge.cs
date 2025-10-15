using System;
using UnityEngine;

public class Fridge : ITemperatureControl
{
    // --- ITemperatureControl Fields ---
    private int _targetTemp = 4; // Default fridge temp in Celsius
    private int _currentTemp = 25; // Assume room temperature when off
    private const int MIN_FRIDGE_TEMP = 1;//Constant (ค่าคงที่) ไม่สามารถถูกเปลี่ยนแปลงได้เลยตลอดอายุการทำงาน
    private const int MAX_FRIDGE_TEMP = 7;//Constant (ค่าคงที่) ไม่สามารถถูกเปลี่ยนแปลงได้เลยตลอดอายุการทำงาน
    public int TargetTemperature { get { return _targetTemp; } set { _targetTemp = value; } }
    public int CurrentTemperature { get { return _currentTemp; } }
    public int MinTemperature { get { return MIN_FRIDGE_TEMP; } }
    public int MaxTemperature { get { return MAX_FRIDGE_TEMP; } }

    // --- ITemperatureControl Methods (Using the methods as defined earlier) ---

    public void SetTemperature(int degrees)
    {
        // Clamp the input temperature to safe fridge limits (1°C to 7°C)
        _targetTemp = Mathf.Clamp(degrees, MinTemperature, MaxTemperature);
        Debug.Log($"Target temperature set to: {_targetTemp}°C");

    }

    public int GetCurrentTemperature()
    {
        // Simulate gradual cooling/warming if the fridge is on/off
        if (_currentTemp > _targetTemp)
        {
            // Simulate cooling
            _currentTemp--;
        }
        else if (_currentTemp < 25)
        {
            // Simulate warming up to room temp
            _currentTemp++;
        }

        return _currentTemp;
    }
}
