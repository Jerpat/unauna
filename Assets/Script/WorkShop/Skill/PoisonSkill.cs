using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.TextCore.Text;

public class PoisonSkill : Skill
{
    public int DamageAmount = 5;
    public float Duration;
    private float tickTimer = 1f;

    Enemy target;

    public PoisonSkill()
    {
        this.skillName = "Poison Skill";
        this.cooldownTime = 10;
        this.Duration = 6;
        this.durationSkill = true;
    }

    public override void Activate(Character character)
    {
        timer = Duration;

        target = GetEnemyNearest(character);

        if (target != null)
        {
            target.TakeDamage(DamageAmount);
        }
        else
        {
            Debug.Log("No enemies");
        }
    }

    public override void Deactivate(Character character)
    {
        Debug.Log("Deactivate : " + skillName);
    }

    public override void UpdateSkill(Character character)
    {
        timer -= Time.deltaTime;
        tickTimer -= Time.deltaTime;

        if (tickTimer <= 0f && timer > 0f)
        {
            target.TakeDamage(DamageAmount);
            Debug.Log("Casting skill poison = 5 damage");
            tickTimer = 1f;
        }

        if (timer <= 0f)
        {
            Deactivate(character);
        }
    }

    private Enemy GetEnemyNearest(Character caster)
    {
        Collider[] hitColliders = Physics.OverlapSphere(caster.transform.position, 5);

        Enemy nearestEnemy = null;
        float nearestDistance = Mathf.Infinity;

        foreach (var hitCollider in hitColliders)
        {
            Enemy targetCharacter = hitCollider.GetComponent<Enemy>();
            if (targetCharacter != null && targetCharacter != caster)
            {
                float distance = Vector3.Distance(caster.transform.position, targetCharacter.transform.position);
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestEnemy = targetCharacter;
                }
            }
        }
        return nearestEnemy;
    }
}
