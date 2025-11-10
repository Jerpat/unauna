using System;
using UnityEngine;

public class HealSkill : Skill
{
    public int HealAmount = 25;

    public HealSkill()
    {
        this.skillName = "Heal";
        this.cooldownTime = 5;
    }
    public override void Activate(Character character)
    {
        Debug.Log("Casting skill heal = 25");
        character.Heal(HealAmount);
    }

    public override void Deactivate(Character character)
    {
        throw new NotImplementedException();
    }

    public override void UpdateSkill(Character charater)
    {
        throw new NotImplementedException();
    }
}
