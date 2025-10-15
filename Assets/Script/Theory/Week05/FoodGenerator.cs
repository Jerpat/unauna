using System;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // สร้างลิสต์ของ Food
        List<Food> Order = new List<Food>();
        // เพิ่ม Pizza และ Burger เข้าไปในลิสต์
        //Food food = new Food(); ไม่สามารถสร้าง object ของคลาส Food ได้โดยตรง เพราะเป็นคลาส abstract

        Order.Add(new Burger(true, 550));
        List<string> pizzaToppings = new List<string> { "Pepperoni", "Mushrooms", "Onions" };
        Order.Add(new Pizza("Pepperoni", 600, "L", pizzaToppings));

        // วนลูปเพื่อจัดการกับอาหารแต่ละชนิด
        foreach (Food item in Order)
        {
            item.DisplayInfo();
            item.Prepare();
            item.Eat();
        }
    }

    
}
