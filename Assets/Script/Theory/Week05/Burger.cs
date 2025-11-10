using System;
using UnityEngine;

public class Burger : Food
{
    public bool HasCheese;

    public Burger(bool hasCheese, double price) : base("Burger", price, "FastFood")
    {
        HasCheese = hasCheese;
    }

    public override void Prepare()
    {
        Debug.Log($"Ky is grilled");
        if (HasCheese)
        {
            Debug.Log("With Cheese");
        }
        else
        {
            Debug.Log("Without Cheese");
        }
    }

    public override void Eat()
    {
        Debug.Log("Big Bite Burger");
    }
}
