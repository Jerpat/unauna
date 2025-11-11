using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private List<IQuest> _activeObjectives = new List<IQuest>();

    void Start()
    {
        // ตัวอย่างการเพิ่มเควส (ในโค้ดจริงอาจมาจากที่อื่น)
        AddQuestObjective(new KillObjective("Wolf", 5));
    }

    // เมธอดสำหรับเพิ่มเควสใหม่
    public void AddQuestObjective(IQuest objective)
    {
        _activeObjectives.Add(objective);
        objective.OnObjectiveCompleted += HandleObjectiveCompleted;
    }

    // เมธอดที่ QuestManager ใช้ "ฟัง" การตายของศัตรู
    public void SubscribeToEnemyDeath(IDestroyable enemy)
    {
        enemy.OnDestroy += HandleEnemyDied;
    }

    // Handler สำหรับ Event การตายของศัตรู
    private void HandleEnemyDied(IDestroyable enemy)
    {
        // 1. ตรวจสอบประเภทศัตรูที่ตาย
        string enemyType = enemy.GetType().Name; // ในตัวอย่างคือ "Wolf"

        // 2. วนลูปเช็ค Active Objectives ที่เกี่ยวข้อง
        foreach (var obj in _activeObjectives)
        {
            // *** นี่คือหัวใจสำคัญ: การ Casting/Checking ***
            // เราเช็คว่า objective นี้เป็นประเภท KillObjective ที่ต้องการ 'Wolf' หรือไม่
            if (obj is KillObjective killObj && killObj.IsComplete == false)
            {
                // สมมติว่า KillObjective เก็บชื่อที่ต้องการไว้ (โค้ดจริงจะซับซ้อนกว่านี้)
                // เราจะเรียก UpdateProgress โดยไม่ต้องรู้ว่า KillObjective ทำงานอย่างไร
                killObj.UpdateProgress(1);
                Debug.Log($"Quest Progress: {obj.GetProgressText()}");
            }
        }
    }

    private void HandleObjectiveCompleted()
    {
        // ... จัดการเมื่อเป้าหมายเควสสำเร็จ (เช่น ลบออกจาก Active Objectives, แจ้งผู้เล่น)
        Debug.Log("An objective has been successfully completed!");
    }
}
