using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SkillBook : MonoBehaviour
{
    public List<Skill> skillsSet = new List<Skill>();
    public GameObject[] skillEffects;
    List<Skill> activeSkills = new List<Skill>();

    Player player;
    public void Start()
    {
        // เพิ่มสกิลต่างๆ เข้าไปใน List
        player = GetComponent<Player>();

        skillsSet.Add(new FireballSkill());
        skillsSet.Add(new HealSkill());
        skillsSet.Add(new BuffSkillMoveSpeed());
        skillsSet.Add(new HealOvertimeSkill());
        skillsSet.Add(new PoisonSkill());

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseSkill(0); // 1 (Fireball)
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseSkill(1); // 2 (Heal)
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            UseSkill(2); // 3 (Buff Move Speed)
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            UseSkill(3); // 4 (Heal Overtime)
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            UseSkill(4); // 5 (Poison Overtime)
        }
        // อัปเดตสกิลที่มีผลต่อเนื่อง

        for (int i = 0; i < activeSkills.Count; i++) {
            activeSkills[i].UpdateSkill(player);
            if (activeSkills[i].timer <= 0)
            {
                activeSkills.Remove(activeSkills[i]);
            }

        }
       
    }

    public void UseSkill(int index)
    {
        if (index >= 0 && index < skillsSet.Count)
        {
            Skill skill = skillsSet[index];
            if (!skill.IsReady(Time.time))
            {
                Debug.Log("Skill is cooldown");
                return;
            }

            GameObject g = Instantiate(skillEffects[index], transform.position, Quaternion.identity, transform);
            Destroy(g, 1);

            skill.Activate(player);
            skill.TimeStampSkill(Time.time);
            if (skill.durationSkill)
            {
                activeSkills.Add(skill);
            }
            
        }
    }
    private void OnDrawGizmos()
    {
        // Set the gizmo color
        Gizmos.color = Color.yellow;
        // Draw a wire sphere at the player's position with the fireball's search radius
        Gizmos.DrawWireSphere(transform.position, 5);
        
    }
}
