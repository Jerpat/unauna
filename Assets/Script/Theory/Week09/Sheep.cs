using System;
using UnityEngine;

public class Sheep 
{
    public int sheepNumber;
    public static int totalSheepCount;

    public static readonly int _innitialPopulation = 5;

    static Sheep()
    {
        totalSheepCount = _innitialPopulation;
    }

    public static int MaxSheepCount
    {
        get
        {
            return totalSheepCount;
        }
    }

    public Sheep(int i)
    {
        this.sheepNumber = i;
        totalSheepCount++;
        Debug.Log("Sheep Number: " + i + " has been created");
    }

    public int AskNumber()
    {
        return sheepNumber;
    }

    public static int GetAllSheep()
    {
        // return SheepNumber; for static
        return totalSheepCount;
    }

    public void SetNumber(int i)
    {
        sheepNumber = i;
    }
    
    public static void RemoveSheep(int count)
    {
        totalSheepCount -= count;
        Debug.Log("Remove sheep, Total sheep is " + totalSheepCount);
    }

    public void Jump()
    {
        Debug.Log("Sheep jump sheep got gravity " + FarmUtils.Gravity);
    }
}
