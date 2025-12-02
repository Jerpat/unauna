using System;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static MerchantGovernor;

public class QuestManagerScene2 : MonoBehaviour
{
    //Set up
    public static QuestManagerScene2 instance; //
    public string LoadScene3Name;
    public int currentQuest2Progress = 0;
    public GameObject BarrierWall;

    //Quest Text 
    public GameObject QuestPanel;
    public TMP_Text QuestText;
    public Slider Quest2ProgressBar;

    //Check if the quest is on going or not
    public bool IsActive = false;
    public bool QuestIsCompleted = false;

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
        QuestText.text = "Quest: Find and Collect Glowing Crystal"; //+ "(" + currentQuestProgress + "/3)";
        IsActive = true;
        Debug.Log("Quest 2 Started");
    }

    public void OnGoingQuest(int progress)
    {
        //Quest Info
        Quest2ProgressBar.value = currentQuest2Progress;
        currentQuest2Progress += progress;
        Debug.Log("Currently Quest: Find Glowing Crystal"); //
        if (IsActive == true && currentQuest2Progress > 0) //
        {

            //QuestText.text = "Quest: Completed! (Talk to Merchant Governor to countinue)";
            //CompletedQuest();
            //MerchantGovernor.quest1State == QuestState.Completed;
            QuestText.text = "Quest Completed! Talk to [Merchant Governor] to continue";
            IsActive = false;
            QuestIsCompleted = true;
        }
    }

    //public void CompletedQuest()
    //{
    //    //Load new scene
    //    IsActive = false;
    //    QuestPanel.gameObject.SetActive(false);
    //    LoadSceneManager.instance.LoadNewScene(LoadSceneName);
    //    Debug.Log("Quest 2 Completed");
    //}

    public void CompletedQuest()
    {
        //Quest now ended
        QuestText.text = "Quest Completed! Talk to [Merchant Governor] to continue";
        //QuestPanel.gameObject.SetActive(false);
        Debug.Log("Quest 2 Completed");
        //MerchantGovernor.instance.GiveRewardScene1();
    }

    public void ClearedQuest()
    {
        QuestPanel.gameObject.SetActive(false);
        BarrierWall.gameObject.SetActive(false);
        //LoadSceneManager.instance.LoadNewScene(LoadScene3Name);
    }
}