using System;
using UnityEngine;

public class AirConditioner : MonoBehaviour, ITemperatureControl ,ISwitchControl
{
    // --- Fields and Constants ---
    private bool _isOn = false;
    private int _targetTemp = 25;
    private int _currentTemp = 30;

    // Property จาก IPowerControl
    //1. Full-Body Get/Set Accessor (รูปแบบดั้งเดิม)
    public bool isOn { get { return _isOn; } set { _isOn = value; } }
    //2. Expression-Bodied Get/Set (รูปแบบย่อด้วย =>)
    public int TargetTemperature { get => _targetTemp; set => _targetTemp = value; }
    //3. Read-Only
    //3.1 Read-Only Expression
    public int CurrentTemperature => _currentTemp;
    //3.2 Read-Only Full
    public int MinTemperature { get { return 18; } }
    //4. Auto-Implemented Property (รูปแบบสั้นที่สุด)
    public int MaxTemperature { get; } = 30;

    // --- IPowerControl Methods ---

    public bool IsPoweredOn()
    {
        return isOn;
    }

    public void TurnOff()
    {
        if (isOn)
        {
            isOn = false;
            Debug.Log("Air Conditioner turned OFF.");
        }
        else
        {
            Debug.Log("AC is already off.");
        }
    }

    public void TurnOn()
    {
        if (!isOn)
        {
            isOn = true;
            Debug.Log("❄️ Air Conditioner turned ON. Cooling started.");
        }
        else
        {
            Debug.Log("AC is already on.");
        }
    }

    // --- ITemperatureControl Methods ---

    public void SetTemperature(int degrees)
    {
        if (isOn)
        {
            // ใช้ Math.Max และ Math.Min ในการจำกัดค่า (Clamping)
            _targetTemp = Math.Max(MinTemperature, Math.Min(degrees, MaxTemperature));

            Debug.Log($"Target temperature set to: {_targetTemp}°C");
        }
        else
        {
            Debug.Log("❌ Cannot set temperature; AC is OFF.");
        }
    }

    public int GetCurrentTemperature()
    {
        // จำลองการปรับอุณหภูมิเข้าหาเป้าหมาย
        if (isOn)
        {
            if (_currentTemp > _targetTemp)
                _currentTemp--;
            else if (_currentTemp < _targetTemp)
                _currentTemp++;
        }
        return _currentTemp;
    }

}
