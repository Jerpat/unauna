using System;
using UnityEngine;

public abstract class Food : MonoBehaviour
{
    // คุณสมบัติที่อาหารทุกชนิดมี
    public string Name;
    public double Price;

    // คอนสตรักเตอร์สำหรับคลาสแม่
    public Food(string name, double price)
    {
        Name = name;
        Price = price;
    }

    // Abstract Method: พฤติกรรมที่ต้องให้คลาสลูกเขียนโค้ดเอง
    // นี่คือ "สัญญา" ว่าอาหารทุกชนิดต้องมีวิธีเตรียมและรับประทาน
    public abstract void Prepare();
    public abstract void Eat();

    // เมธอดปกติที่มีโค้ดการทำงานอยู่แล้ว
    public void DisplayInfo()
    {
        Debug.Log($"--- Food Info ---");
        Debug.Log($"Name: {Name}");
        Debug.Log($"Calories: {Price} kcal");
    }

}
