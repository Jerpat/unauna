using System;
using UnityEngine;

public abstract class Skill
{
    public string skillName;
    public float cooldownTime;
    public float lastUsedTime;
    public bool durationSkill;
    public float timer;

    public abstract void Activate(Character character);

    public abstract void Deactivate(Character character);

    public abstract void UpdateSkill(Character charater);

    public bool IsReady(float GameTime)
    {
        return GameTime > lastUsedTime + cooldownTime;
    }

    public void TimeStampSkill(float GameTime)
    {
        lastUsedTime = GameTime;
    }

    public void DisplayInfo()
    {
        Debug.Log("Skiil : " + skillName);
        Debug.Log("Cooldown : " + cooldownTime);
    }
}
