using System;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public string Name = "";
    public float Health;
    public int Age;

    // Constructor ของ Base Class
    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
        Health = 100.0f; // เริ่มต้นสุขภาพที่ 100
        Debug.Log($"A new animal named {Name} was created.");
    }
    
    public void Eat(string food) // เมธอดที่คลาสลูกจะสืบทอดไป
    {
        if (food != string.Empty)
        {
            Health += 10.0f;
            Debug.Log($"{Name} is eating {food}.");
        }
        else
        {
            Health -= 10.0f;
            Debug.Log($"{Name} has nothing to eat.");
        }
        Health = Mathf.Clamp(Health, 0, 100.0f); // กินแล้วสุขภาพเพิ่มขึ้น แต่ไม่เกิน 100

    }

    // เมธอดนี้จะให้คลาสลูกไปเขียนรายละเอียดการส่งเสียงเอง
    // ใช้ virtual เพื่อให้คลาสลูกสามารถ Override ได้
    public virtual void MakeSound()
    {
        Debug.Log($"{Name} makes a generic sound.");
    }
    

    
}
