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
    public static QuestManagerScene2 instance; 
    public int currentQuest2Progress = 0;
    public GameObject BarrierWall2;

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
        QuestText.text = "Quest 2: Kill all Buzzvenoms"; //+ "(" + currentQuestProgress + "/3)";
        IsActive = true;
        Debug.Log("Quest 2 Started");
    }

    public void OnGoingQuest(int progress)
    {
        //Quest Info
        currentQuest2Progress += progress;
        Quest2ProgressBar.value = currentQuest2Progress;
        Debug.Log($"Kills Count = {currentQuest2Progress}");
        if (IsActive == true && currentQuest2Progress == 3) 
        {

            //QuestText.text = "Quest: Completed! (Talk to Merchant Governor to countinue)";
            //CompletedQuest();
            //MerchantGovernor.quest1State == QuestState.Completed;
            QuestText.text = "Quest Completed! Talk to [Merchant Governor] to continue";
            IsActive = false;
            QuestIsCompleted = true;
        }
    }

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
        BarrierWall2.gameObject.SetActive(false);
        //LoadSceneManager.instance.LoadNewScene(LoadScene3Name);
    }
}