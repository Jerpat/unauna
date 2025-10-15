using System;
using System.Collections.Generic;
using UnityEngine;

public class ElectronicGenerator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 1. ตัวอย่างการใช้ Polymorphism ผ่าน ISwitchControl
        // สร้าง List ของอุปกรณ์ที่สามารถเปิด/ปิดได้
        LightBulb lightBulb = new LightBulb();
        lightBulb.TurnOn();
        lightBulb.TurnOff();
        Debug.Log(lightBulb.isOn);

        PortableFan fan = new PortableFan();
        fan.TurnOff();
        fan.TurnOn();
        fan.TurnOn();
        fan.TurnOn();
        fan.TurnOn();
        Debug.Log(fan.isOn);


        List<ISwitchControl> switchableDevices = new List<ISwitchControl>();

        // เพิ่ม AirConditioner และ lightBulb เข้าไปใน List (ใช้ Reference เป็น ISwitchControl)
        switchableDevices.Add(lightBulb);
        switchableDevices.Add(fan);

        Debug.Log("--- 1. การทำงานร่วมกันผ่าน ISwitchControl (เปิด/ปิด) ---");

        foreach (var device in switchableDevices)
        {
            // สามารถเรียกใช้ TurnOn ได้กับทุก Object ใน List
            device.TurnOn();
        }

        Debug.Log("\n--- สั่งปิดทั้งหมด ---");
        foreach (var device in switchableDevices)
        {
            device.TurnOff();
        }
    }

}
