using System;
using UnityEngine;

public class BankAccountGenerator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //1. สร้าง Object ของบัญชีธนาคารทั่วไป (Base Class)
        BankAccount generalAccount = new BankAccount("B-67890", "general_pass", 500, "MainBranch");
        generalAccount.AccountNumber = "B-67890"; // public: สามารถเข้าถึงได้
        generalAccount.BranchId = "NewBranch"; // internal: สามารถเข้าถึงได้เพราะอยู่ใน Assembly เดียวกัน
        generalAccount.Deposit(200); // public: สามารถเข้าถึงได้ ฝากเงินได้

        //2. ลองเข้าถึงฟิลด์และเมธอดที่มีการกำหนดระดับการเข้าถึงต่างๆ
        // generalAccount._balance = 1000; // protected: ไม่สามารถเข้าถึงได้จากภายนอก
        // generalAccount.Withdraw(100); // protected: ไม่สามารถเข้าถึงได้จากภายนอก
        // generalAccount._passwordHash = "new_pass"; // private: ไม่สามารถเข้าถึงได้จากภายนอก
        // generalAccount.VerifyPassword("password"); // private: ไม่สามารถเข้าถึงได้จากภายนอก

        //3. เรียกเมธอดที่ใช้การห่อหุ้มว่าจะเข้าถึงรหัสผ่านได้อย่างไร
        generalAccount.CheckPassword("general_pass"); // public: สามารถเข้าถึงได้อธิบายที่มาและวิธีคิด



        //6. สร้าง Object ของบัญชีออมทรัพย์
        SavingsAccount myAccount = new SavingsAccount("S-12345", "my_secret_pass", 1000, "SecondaryBranch", 0.05f);
        Debug.Log($"Account Number: {myAccount.AccountNumber}");// public: สามารถเข้าถึงได้
        Debug.Log($"Branch ID: {myAccount.BranchId}");// internal: สามารถเข้าถึงได้เพราะอยู่ใน Assembly เดียวกัน
        myAccount.Deposit(500);// public: สามารถเข้าถึงได้ ฝากเงินได้

        //7. ลองเข้าถึงฟิลด์และเมธอดที่มีการกำหนดระดับการเข้าถึงต่างๆ
        // protected: ไม่สามารถเข้าถึงได้จากภายนอก
        // myAccount._balance = 2000; // ERROR!
        // myAccount.Withdraw(100); // ERROR!

        // private: ไม่สามารถเข้าถึงได้จากภายนอก
        // myAccount._passwordHash = "new_pass"; // ERROR!
        // myAccount.VerifyPassword("password"); // ERROR!

        //10. เรียกเมธอดที่ใช้การห่อหุ้ม
        myAccount.WithdrawFunds(200f, "my_secret_pass");
        myAccount.WithdrawFunds(50f, "wrong_pass");

        myAccount.AddMonthlyInterest();
    }


}
