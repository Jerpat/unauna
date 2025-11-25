using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestManagerScene2 : MonoBehaviour
{
    //Set up
    public static QuestManagerScene2 instance; //
    public string LoadSceneName;
    public int currentQuest2Progress = 0;

    //Quest Text 
    public GameObject QuestPanel;
    public TMP_Text QuestText;
    public Slider Quest2ProgressBar;

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
        QuestText.text = "Quest: Find and Collect Test Item1!"; //+ "(" + currentQuestProgress + "/3)";
        IsActive = true;
        Debug.Log("Quest Started");
    }

    public void OnGoingQuest(int progress)
    {
        //Quest Info
        Quest2ProgressBar.value = currentQuest2Progress;
        currentQuest2Progress += progress;
        Debug.Log("Currently Quest: Find an item"); //
        if (IsActive == true && currentQuest2Progress > 0) //
        {

            //QuestText.text = "Quest: Completed! (Talk to Merchant Governor to countinue)";
            CompletedQuest();
        }
    }

    public void CompletedQuest()
    {
        //Load new scene
        IsActive = false;
        QuestPanel.gameObject.SetActive(false);
        LoadSceneManager.instance.LoadNewScene(LoadSceneName);
        Debug.Log("Quest Completed");
    }
}