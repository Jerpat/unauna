using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestManagerScene1 : MonoBehaviour
{
    //Set up
    public static QuestManagerScene1 instance;
    public string LoadScene2Name;
    public int currentQuest1Progress = 0;
    public GameObject BarrierWall1;

    //Quest Text 
    public GameObject QuestPanel;
    public TMP_Text QuestText;
    public Slider Quest1ProgressBar;

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
        QuestText.text = "Quest 1: Fight [Deathloard] and get a [Glowing Crystal]"; //+ "(" + currentQuestProgress + "/3)";
        IsActive = true;
        Debug.Log("Quest 1 Started");
    }

    
    public void OnGoingQuest(int progress)
    {
        //Quest Info
        currentQuest1Progress += progress;
        Quest1ProgressBar.value = currentQuest1Progress;
        Debug.Log("Currently Quest: Find Glowing Crystal");
        if (IsActive == true && currentQuest1Progress > 0)
        {
            QuestText.text = "Quest Completed! Talk to [Merchant Governor] to continue";
            IsActive = false;
            QuestIsCompleted = true;
        }
    }
    public void CompletedQuest()
    {
        //Quest now ended
        //QuestText.text = "Quest Completed! Talk to [Merchant Governor] to continue";
        //QuestPanel.gameObject.SetActive(false);
        Debug.Log("Quest 1 Completed");
        //MerchantGovernor.instance.GiveRewardScene1();
    }

    public void ClearedQuest()
    {
        QuestPanel.gameObject.SetActive(false);
        BarrierWall1.gameObject.SetActive(false);
        //LoadSceneManager.instance.LoadNewScene(LoadScene3Name);
    }
}
