using UnityEngine;

public interface Idestoryable
{
    // คุณสมบัติสำหรับค่าพลังชีวิตปัจจุบัน
    int health { get; set; }

    // คุณสมบัติสำหรับค่าพลังชีวิตสูงสุด (อาจใช้หรือไม่ก็ได้)
    int maxHealth { get; set; }

    // เมธอดสำหรับรับความเสียหาย
    void TakeDamage(int damageAmount) { 
        health -= damageAmount;
    }
    event System.Action<Idestoryable> OnDestory;

}
