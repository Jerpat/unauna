using System;
using UnityEngine;

public class SheepGenerator : MonoBehaviour
{
    
    void Start()
    {
        Sheep Apple = new Sheep(1);
        Sheep Beans = new Sheep(2);
        Sheep Cookie = new Sheep(3);
        Sheep Donut = new Sheep(4);

        Debug.Log("Donut is number: " + Beans.AskNumber());
        Debug.Log("Donut is number: " + Donut.sheepNumber);
        Debug.Log("Total sheep: " + Sheep.GetAllSheep());
        Debug.Log("Total sheep: " + Sheep.totalSheepCount);

        Cookie.SetNumber(2);
        Debug.Log("Cookie is number: " + Cookie.AskNumber());
        Sheep.RemoveSheep(1);

        int wool = FarmUtils.CalculateWoolCapacity(Sheep.totalSheepCount);
        Debug.Log("My farm wool capacity is " + wool);
        Debug.Log("This month dat time is " + FarmUtils.DayTime);
    }
}
