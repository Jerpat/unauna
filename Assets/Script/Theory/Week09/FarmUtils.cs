using System;
using UnityEngine;

public static class FarmUtils // static class cant be create new and will be global
{
    public const int WoolCapacity = 2; // const from constant(automately static), works before program compire
    public const float Gravity = 9.8f;

    public static readonly float DayTime = (DateTime.Now.Month >=4 )? 10:8;
    public static readonly float NightTime = (DateTime.Now.Month >= 4)? 4:6;

    public static int CalculateWoolCapacity(int amount)
    {
        return WoolCapacity * amount;
    }
}
