using System;
using UnityEngine;

public abstract class Skill
{
    public string skillName;
    public float cooldownTime;
    public float lastUsedTime = float.MinValue; // เวลาล่าสุดที่ใช้สกิล
    public float timer; // ตัวจับเวลาสำหรับสกิลที่มีผลต่อเนื่อง

    // เมธอดที่เป็น abstract, บังคับให้คลาสลูกต้อง implement
    public abstract void Activate(Character character);
    public abstract void Deactivate(Character character);
    public abstract void UpdateSkill(Character character);
    public void ResetCooldown()
    {
        lastUsedTime = float.MinValue; // เวลาล่าสุดที่ใช้สกิล
    }
    public bool IsReady(float GameTime)
    {
        return GameTime >= lastUsedTime + cooldownTime;
    }

    // เมธอดสำหรับบันทึกเวลาที่ใช้สกิล
    public void TimeStampSkill(float GameTime)
    {
        lastUsedTime = GameTime;
    }

    // เมธอดที่มีการใช้งานร่วมกัน
    public void DisplayInfo()
    {
        Debug.Log($"Skill: {skillName}");
        Debug.Log($"Cooldown: {cooldownTime}s");
    }
}
