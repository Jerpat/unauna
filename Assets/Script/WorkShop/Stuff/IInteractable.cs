using UnityEngine;
using TMPro;
public interface IInteractable
{
    // คุณสมบัติสำหรับชื่อวัตถุ
    bool isInteractable { get; set; }
    // เมธอดที่ต้องมีเพื่อรองรับการโต้ตอบ
    void Interact(Player player);


}
