using UnityEngine;

public class HealOvertimeSkill : Skill
{
    public int HealAmount = 1;
    public float Duration;

    public HealOvertimeSkill()
    {
        this.skillName = "Heal Overtime";
        this.cooldownTime = 7;
        this.Duration = 5;
        this.durationSkill = true;
    }

    public override void Activate(Character character)
    {
        timer = Duration;
        character.Heal(HealAmount);
    }

    public override void Deactivate(Character character)
    {
        Debug.Log("Deactivate : " + skillName);
    }

    public override void UpdateSkill(Character charater)
    {
        timer -= Time.deltaTime;

        charater.Heal(HealAmount);
        Debug.Log("Casting skill heal = 1");

        if (timer <= 0)
        {
            Deactivate(charater);
        }
    }
}
