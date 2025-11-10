using System;
using UnityEngine;

public class Person : MonoBehaviour
{
    // C# จะสร้าง private field ชื่อ backing field ให้โดยอัตโนมัติ
    //1. Auto-Implemented Property
    public string FirstName;
    public string LastName;
    public double HeightInMeters { get; set; }
    public double WeightInKg { get; set; }
    //2. Full Property (รูปแบบเต็ม) เป็นรูปแบบที่สมบูรณ์ที่สุด เหมาะสำหรับเมื่อคุณต้องการควบคุมการเข้าถึงข้อมูลอย่างละเอียด
    private int _heartRate; // private field
    public int HeartRate // public property
    {
        get
        {
            return _heartRate; // อ่านค่าจาก _age
        }
        set
        {
            // Logic การตรวจสอบ: ตรวจสอบว่าค่าที่รับมา (value) ไม่เกินกำหนด
            if (value >= 60 && value <= 250)
            {
                Debug.Log("HeartRate is set " + value);
                _heartRate = value; // กำหนดค่าให้ _age
            }
            else
            {
                Debug.Log("HeartRate should be 60 - 250.");
            }
        }
    }

    //3. Property แบบ Read-Only (อ่านได้อย่างเดียว)
    //วิธีที่ 1: ใช้ public get; private set;
    public string IdCardNumber { get; private set; }
    //วิธีที่ 2: ใช้ public get; อย่างเดียว
    public DateTime BrithDay { get; }
    public int Age
    {
        get {
            int _age = DateTime.Today.Year - BrithDay.Year;
            return _age; // Read-only property
        }
    }
    public double Bmi => WeightInKg / (HeightInMeters * HeightInMeters); // Read-only property
    public Person(string idCardNumber, DateTime brithDay)
    {
        IdCardNumber = idCardNumber;
        BrithDay = brithDay;
    }
    //4. Property แบบ Write-Only (เขียนได้อย่างเดียว)
    private string _password;

    public string Password
    {
        set
        {
            if (value.Length >= 8)
            {
                _password = value;
                Debug.Log("Password set successfully.");
            }
            else
            {
                Debug.Log("Password must be at least 8 characters long.");
            }
        }
    }
    //5. Protected Property (สำหรับคลาสที่สืบทอดเท่านั้น)
    private int _employeeId;

    public int EmployeeId
    {
        get
        {
            return _employeeId;
        }
        protected set
        {
            _employeeId = value;
        }
    }
}
