using System;
using UnityEngine;

[CreateAssetMenu(fileName = "HealSkill", menuName = "Skills/HealSkill")]
public class HealSkill : Skill
{
    public int healingAmountPerSecond = 5;

    // ตัวแปรสำหรับเก็บค่าพลังชีวิตที่ต้องฟื้นฟูสะสม
    private float healAccumulator = 0f;
    public HealSkill()
    {
        this.skillName = "Heal";
        this.cooldownTime = 8;
        this.Duration = 5f; // ระยะเวลาที่สกิลมีผล
    }

    public float Duration { get; set; }

    // ต้อง Override เมธอด Activate()
    public override void Activate(Character character)
    {
        Debug.Log("Casting Heal Over Time!");
        timer = Duration;

        // โค้ดที่ใช้ในการฟื้นฟูค่าพลังชีวิต
    }

    public override void Deactivate(Character character)
    {
        Debug.Log("Heal skill duration ended.");
    }

    public override void UpdateSkill(Character character)
    {
        timer -= Time.deltaTime;
        if (timer > 0)
        {
            // สะสมค่าพลังชีวิตที่ต้องฟื้นฟู
            healAccumulator += Time.deltaTime;

            // ถ้าค่าสะสมถึง 1 หรือมากกว่า ให้ทำการฟื้นฟูและหักค่าที่ใช้ไปออก
            if (healAccumulator >= 1)
            {
                character.Heal(healingAmountPerSecond);
                healAccumulator = 0;
                Debug.Log($"{character.Name} heals for {healingAmountPerSecond} HP. Remaining Duration: {timer:F2} seconds.");
            }
        }
        else
        {
            // เมื่อระยะเวลาหมดลง
            Deactivate(character);
        }
    }
}
