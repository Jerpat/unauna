using System;
using UnityEngine;

public class PersonGenerator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("--- Creating a new Person object ---");
        // สร้าง Object ของ Person โดยใช้ constructor
        // ต้องใส่ค่า IdCardNumber และ HeightInMeters เข้าไป
        DateTime BirthDay= new DateTime(1991, 1, 1);
        Person p1 = new Person("1103700012345", BirthDay);

        // 1. Auto-Implemented Property: FirstName, LastName
        // ตั้งค่าชื่อและนามสกุล
        p1.FirstName = "John";
        p1.LastName = "Doe";


        Debug.Log($"Name set to: {p1.FirstName} {p1.LastName}");

        Debug.Log("--- Setting Properties ---");
        // 2. Full Property: HeartRate
        // ตั้งค่าอายุที่ถูกต้อง
        p1.HeartRate = 60;
        Debug.Log($"HeartRate set successfully: {p1.HeartRate}");
        // ลองตั้งค่าอายุที่ผิดพลาด (จะแสดงข้อความเตือน)
        p1.HeartRate = -5;

        // 3. Read-Only Properties: IdCardNumber, HeightInMeters, Bmi
        // IdCardNumber และ HeightInMeters ถูกตั้งค่าตอนสร้าง Object แล้ว
        Debug.Log($"\n--- Accessing Read-Only Properties ---");
        Debug.Log($"ID Card Number: {p1.IdCardNumber}");
        Debug.Log($"Age: {p1.Age:F2} m");

        // กำหนดค่า WeightInKg เพื่อให้ Bmi คำนวณได้
        p1.HeightInMeters = 1.75;
        p1.WeightInKg = 70.0;

        Debug.Log($"Weight: {p1.WeightInKg:F1} kg");
        // Bmi เป็น Read-Only และคำนวณจากค่า Weight และ Height
        Debug.Log($"BMI: {p1.Bmi:F2}");

        // ลองพยายามแก้ไขค่า Read-Only (จะเกิด Compile Error)
        // p1.IdCardNumber = "9999999999999"; // ERROR!
        // p1.HeightInMeters = 1.80; // ERROR!

        // 4. Write-Only Property: Password
        Debug.Log("\n--- Setting Write-Only Property ---");
        // ตั้งค่ารหัสผ่านที่ถูกต้อง (ความยาว 8 ตัวอักษรขึ้นไป)
        p1.Password = "strong_password123";
        // ลองตั้งค่ารหัสผ่านที่สั้นเกินไป
        p1.Password = "short";

        // ลองพยายามอ่านค่ารหัสผ่านกลับมา (จะเกิด Compile Error)
        // string password = p1.Password; // ERROR!
    }
}
