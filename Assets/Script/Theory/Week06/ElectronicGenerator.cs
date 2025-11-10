using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ElectronicGenerator : MonoBehaviour
{
    private void Start()
    {
        LightBulb lightBulb = new LightBulb();
        lightBulb.TurnOn();
        lightBulb.TurnOff();
        Debug.Log("Lightbulb is turn ON " + lightBulb.isOn);

        PortableFan portableFan = new PortableFan();
        portableFan.TurnOn();
        portableFan.TurnOn();
        portableFan.TurnOff();
        portableFan.TurnOn();
        portableFan.TurnOn();
        Debug.Log("Portable Fan is turn ON " + portableFan.isOn);

        List<ISwitchControl> smarthome = new List<ISwitchControl>();
        smarthome.Add(lightBulb);
        smarthome.Add(portableFan);

        Debug.Log("turn off all switch;");
        foreach (var device in smarthome)
        {
            device.TurnOff();
        }

        Debug.Log("come home");
        foreach (var device in smarthome)
        {
            device.TurnOn();
        }

    }
}
