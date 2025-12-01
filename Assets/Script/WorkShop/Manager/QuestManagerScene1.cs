using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestManagerScene1 : MonoBehaviour
{
    //Set up
    public static QuestManagerScene1 instance;
    public string LoadScene1Name;
    public int currentQuestProgress = 0;

    //Quest Text 
    public GameObject QuestPanel;
    public TMP_Text QuestText;
    public Slider QuestProgressBar;

    //Check if the quest is on going or not
    public bool IsActive = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        //Quest UI Setting
        QuestPanel.gameObject.SetActive(false);
    }

    public void StartQuest()
    {
        //Quest UI Setting
        QuestPanel.gameObject.SetActive(true);
        QuestText.text = "Quest: Kill all Slimes!"; //+ "(" + currentQuestProgress + "/3)";
        IsActive = true;
        Debug.Log("Quest 1 Started");
    }

    
    public void OnGoingQuest(int progress)
    {
        //Quest Info
        QuestProgressBar.value = currentQuestProgress;
        currentQuestProgress += progress;
        Debug.Log($"Kills Count = {currentQuestProgress}");
        if (IsActive == true && currentQuestProgress == 3)
        {

            QuestText.text = "Quest: Completed! (Talk to Merchant Governor to countinue)";
            CompletedQuest();
        }
    }

    //public void ClearedQuest()
    //{
    //    //Load new scene
    //    IsActive = false;
    //    QuestPanel.gameObject.SetActive(false);
    //    //LoadSceneManager.instance.LoadNewScene(LoadScene1Name);
    //    Debug.Log("Quest Completed");
    //}

    public void CompletedQuest()
    {
        //Load new scene
        IsActive = false;
        QuestPanel.gameObject.SetActive(false);
        LoadSceneManager.instance.LoadNewScene(LoadScene1Name);
        Debug.Log("Quest 1 Completed");
        //MerchantGovernor.instance.GiveRewardScene1();
    }



    //private List<IQuest> _activeObjectives = new List<IQuest>();

    //void Start()
    //{
    //    // ตัวอย่างการเพิ่มเควส (ในโค้ดจริงอาจมาจากที่อื่น)
    //    AddQuestObjective(new KillObjective("Wolf", 5));
    //}

    //// เมธอดสำหรับเพิ่มเควสใหม่
    //public void AddQuestObjective(IQuest objective)
    //{
    //    _activeObjectives.Add(objective);
    //    objective.OnObjectiveCompleted += HandleObjectiveCompleted;
    //}

    //// เมธอดที่ QuestManager ใช้ "ฟัง" การตายของศัตรู
    //public void SubscribeToEnemyDeath(IDestroyable enemy)
    //{
    //    enemy.OnDestroy += HandleEnemyDied;
    //}

    //// Handler สำหรับ Event การตายของศัตรู
    //private void HandleEnemyDied(IDestroyable enemy)
    //{
    //    // 1. ตรวจสอบประเภทศัตรูที่ตาย
    //    string enemyType = enemy.GetType().Name; // ในตัวอย่างคือ "Wolf"

    //    // 2. วนลูปเช็ค Active Objectives ที่เกี่ยวข้อง
    //    foreach (var obj in _activeObjectives)
    //    {
    //        // *** นี่คือหัวใจสำคัญ: การ Casting/Checking ***
    //        // เราเช็คว่า objective นี้เป็นประเภท KillObjective ที่ต้องการ 'Wolf' หรือไม่
    //        if (obj is KillObjective killObj && killObj.IsComplete == false)
    //        {
    //            // สมมติว่า KillObjective เก็บชื่อที่ต้องการไว้ (โค้ดจริงจะซับซ้อนกว่านี้)
    //            // เราจะเรียก UpdateProgress โดยไม่ต้องรู้ว่า KillObjective ทำงานอย่างไร
    //            killObj.UpdateProgress(1);
    //            Debug.Log($"Quest Progress: {obj.GetProgressText()}");
    //        }
    //    }
    //}

    //private void HandleObjectiveCompleted()
    //{
    //    // ... จัดการเมื่อเป้าหมายเควสสำเร็จ (เช่น ลบออกจาก Active Objectives, แจ้งผู้เล่น)
    //    Debug.Log("An objective has been successfully completed!");
    //}
}
