using System;
using UnityEngine;

public class SavingsAccount : BankAccount
{
    // public: อัตราดอกเบี้ย
    public float InterestRate { get; set; }

    // Constructor ของ SavingsAccount
    public SavingsAccount(string accountNumber, string passwordHash, float initialBalance, string branchId, float interestRate)
        : base(accountNumber, passwordHash, initialBalance, branchId)
    {
        InterestRate = interestRate;
        Debug.Log($"Savings account {AccountNumber} created with interest rate {InterestRate:P}.");
    }

    //9. public: เมธอดสำหรับถอนเงินที่ถูกควบคุม
    //ใช้การห่อหุ้ม (Encapsulation) โดยตรวจสอบรหัสผ่านก่อน
    //ทดสอบการเข้าถึง protected method จากคลาสลูก
    public void WithdrawFunds(float amount, string password)
    {
        if (CheckPassword(password))
        {
            // เรียกใช้ protected method ของ Base Class ได้
            Withdraw(amount);
        }
        else
        {
            Debug.Log("Incorrect password. Withdrawal failed.");
        }
    }

    //8. public: เมธอดเฉพาะของ SavingsAccount
    //ทดสอบการเข้าถึง protected field จากคลาสลูก
    public void AddMonthlyInterest()
    {
        float interest = _balance * InterestRate;
        _balance += interest; // สามารถเข้าถึง protected field ได้
        Debug.Log($"Added monthly interest of {interest:C}. New balance: {_balance:C}");
    }
}
