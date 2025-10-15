using System;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : Food
{
    public string Size { get; set; } // Small, Medium, Large
    public List<string> Toppings { get; set; }
    public Pizza(string name, double price, string size, List<string> toppings)
        : base(name, price) // เรียกคอนสตรักเตอร์ของคลาสแม่
    {
        Size = size;
        Toppings = toppings;
    }
    public override void Prepare()
    {
        Debug.Log($"Preparing a {Size} pizza named {Name} with toppings: {string.Join(", ", Toppings)}.");
        // โค้ดการเตรียมแป้ง, ซอส, ชีส, และท็อปปิ้งต่างๆ
    }
    public override void Eat()
    {
        Debug.Log($"Eating the delicious {Name} pizza!");
        // โค้ดการกินพิซซ่า
    }
}
