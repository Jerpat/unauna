using System;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        List<Food> Order = new List<Food>();

        Order.Add(new Burger(true, 2000));

        List<string> pizzaToppings = new List<string> {"Apple","Pineapple","Bacon"};
        Order.Add(new Pizza("Hawaiian", 3000, "XL", pizzaToppings));

        foreach (var item in Order)
        {
            item.Prepare();
            item.Eat();
            item.PrintInfo();
        }

    }
    
}
