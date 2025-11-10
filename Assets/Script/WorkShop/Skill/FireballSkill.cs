using System;
using System.Collections.Generic;
using UnityEngine;

public class FireballSkill : Skill
{
    public int DamageAmount = 50;

    public FireballSkill()
    {
        this.skillName = "FireballSkill";
        this.cooldownTime = 5;
    }
    public override void Activate(Character character)
    {
        Enemy[] targets = GetEnemysInRange(character);

        if (targets.Length > 0)
        {
            foreach (Enemy enemy in targets)
            {
                enemy.TakeDamage(DamageAmount);
                Debug.Log($"{character.Name} casts {skillName} on {enemy.Name}," + $"dealing {DamageAmount} damage");
            }
        }
        else
        {
            Debug.Log("No enemies");
        }
    }

    public override void Deactivate(Character character)
    {
    }

    public override void UpdateSkill(Character character)
    {

    }

    private Enemy[] GetEnemysInRange(Character caster)
    {
        // Find all colliders within the search radius
        Collider[] hitColliders = Physics.OverlapSphere(caster.transform.position, 5);
        List<Enemy> Enemys = new List<Enemy>();

        foreach (var hitCollider in hitColliders)
        {
            // Check if the collider belongs to a character that isn't the caster

            Enemy targetCharacter = hitCollider.GetComponent<Enemy>();
            if (targetCharacter != null && targetCharacter != caster)
            {
                Enemys.Add(targetCharacter);
            }
        }
        return Enemys.ToArray();
    }
}
