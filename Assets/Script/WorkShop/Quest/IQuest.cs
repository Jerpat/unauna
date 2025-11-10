using UnityEngine;

public interface IQuest 
{
    // ใช้เพื่อตรวจสอบว่าเป้าหมายนี้สำเร็จแล้วหรือยัง
    bool IsComplete { get; }

    // ข้อความที่แสดงความคืบหน้า (เช่น "Kill 5/10 Wolves")
    string GetProgressText();

    // เมธอดสำหรับอัปเดตความคืบหน้า (ถูกเรียกจากภายนอก)
    void UpdateProgress(int amount);

    // อีเวนต์สำหรับแจ้งเตือนระบบ QuestManager เมื่อสถานะเปลี่ยน
    event System.Action OnObjectiveCompleted;
}
