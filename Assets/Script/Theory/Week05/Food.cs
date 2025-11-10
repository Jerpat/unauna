using System;
using UnityEngine;

public abstract class Food : MonoBehaviour
{
    public string Name;
    public double Price;
    public string Type;

    // cant type in (){} form cuz only inherited class can inherit
    public Food(string name, double price, string type)
    {
        Name = name;
        Price = price;
        Type = type;
    }
    public abstract void Prepare();

    public abstract void Eat();

    public void PrintInfo() //use normal void when every class can do same thing
    {
        Debug.Log("--------print info--------");
        Debug.Log($"Name: {Name}");
        Debug.Log($"Price: {Price}");
    }

}
