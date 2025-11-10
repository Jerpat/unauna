using System;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : Food
{
    public string Size;
    public List<string> Toppings;

    public Pizza(string name, double price, string size, List<string> toppings) : base(name, price, "FastFood")
    {
        Size = size;
        Toppings = toppings;
    }
    public override void Eat()
    {
        Debug.Log("Take one piece and Eat");
    }

    public override void Prepare()
    {
        Debug.Log($"Prepare {Size} pizza {Name} with toppings {Toppings}");
        foreach (var p in Toppings)
        {
            Debug.Log(p);
        }
    }
}
