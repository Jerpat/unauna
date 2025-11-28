using System;
using UnityEngine;

public class BuffSkillMoveSpeed : Skill
{
    public float SpeedIncreaseAmount = 5;
    float OriginalSpeed;
    float targetSpeed;
    public float Duration;

    public BuffSkillMoveSpeed()
    {
        this.skillName = "Speed Boost";
        this.cooldownTime = 5;
        this.Duration = 3;
        this.durationSkill = true;
    }
    public override void Activate(Character character)
    {
        timer = Duration;

        OriginalSpeed = character.walkSpeed;
        targetSpeed = character.walkSpeed + SpeedIncreaseAmount;
        Debug.Log("Activate " + skillName);
    }

    public override void Deactivate(Character character)
    {
        character.walkSpeed = OriginalSpeed;
        Debug.Log("Deactivate : " + skillName);
    }

    public override void UpdateSkill(Character charater)
    {
        timer -= Time.deltaTime;
        charater.walkSpeed = targetSpeed;
        if (timer <= 0)
        {
            Deactivate(charater);
        }
    }
}
