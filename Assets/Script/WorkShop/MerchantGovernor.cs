using TMPro;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MerchantGovernor : Character, IInteractable, ITalkable
{
    //Quest State SetUp
    public enum QuestState { NotGiven, Given, Completed, TurnedIn }
    public QuestState quest1State = QuestState.NotGiven;
    public QuestState quest2State = QuestState.NotGiven;
    public QuestState quest3State = QuestState.NotGiven;

    //Scene SetUp
    private string currentScene;

    //Interface SetUp
    private bool canTalk = true;
    private bool canInteract = true;
    //private bool Quest1 = false;

    //Interact Text
    public TMP_Text interactionTextUI;

    //Talking Conversations Text 
    private bool SingleTalkingLine = false;
    public GameObject TalkingPanel;
    public TMP_Text TalkingText;
    public TMP_Text TalkingNameText;
    public string[] TalkingLines;
    private int index = 0;

    public bool isInteractable { get => canInteract; set => canInteract = value; }
    public bool isTalkable { get => canTalk; set => canTalk = value; }


    public override void SetUP()
    {
        //Interact Text Setting
        interactionTextUI = GetComponentInChildren<TMP_Text>();

        //UI Setting
        TalkingPanel.gameObject.SetActive(false);

        //Scene Setting
        currentScene = SceneManager.GetActiveScene().name;
        Debug.Log("Current Scene = " + currentScene);
    }
    public void Update()
    {
        if (GetDistancePlayer() >= 2f || !canInteract)
        {
            interactionTextUI.gameObject.SetActive(false);
        }
        else
        {
            interactionTextUI.gameObject.SetActive(true);
        }
        //Turn(player.transform.position - transform.position);
    }

    public void Interact(Player player)
    {
        if (SingleTalkingLine)
        {
            TalkingPanel.SetActive(false);
            SingleTalkingLine = false;
            return;
        }
        Talk(player);
        Debug.Log("Interact With Merchant Governor");
    }

    public void Talk(Player player)
    {
        //UI Setting
        TalkingPanel.gameObject.SetActive(true);
        TalkingNameText.text = "Merchant Governor";

        //Talking All Lines before Give Quest
        if (index < TalkingLines.Length)
        {
            TalkingText.text = TalkingLines[index];
            index++;
            return;
        }

        //Give Quest for each Scence (Use Current Scene to check)
        if (currentScene == "01Dungeon")
        {
            TalkingPanel.SetActive(false);
            GiveQuestScene1();
            Debug.Log("Conversation Ended, Give Quest Scene 1");
        }
        else if (currentScene == "02Desert")
        {
            TalkingPanel.SetActive(false);
            GiveQuestScene2();
            Debug.Log("Conversation Ended, Give Quest Scene 2");
        }
        else if (currentScene == "03Forest")
        {
            TalkingPanel.SetActive(false);
            GiveQuestScene3();
            Debug.Log("Conversation Ended, Give Quest Scene 3");
        }
        
        //Close Talking UI PAnel after Talked all Lines and Gave a Quest
        //TalkingPanel.SetActive(false);
    }

    public void GiveQuestScene1()
    {
        if (quest1State == QuestState.NotGiven)
        {
            QuestManagerScene1.instance.StartQuest();
            quest1State = QuestState.Given;
            Debug.Log("Quest 1 Given");
        }
        else if (quest1State == QuestState.Given && QuestManagerScene1.instance.IsActive == true)
        {
            TalkingPanel.SetActive(true);
            TalkingText.text = "Quick! [Find a Glowing Stone] and give it to me!";
            SingleTalkingLine = true;
        }
        else if (quest1State == QuestState.Completed && QuestManagerScene1.instance.IsActive == false)
        {
            QuestManagerScene1.instance.ClearedQuest();
            TalkingPanel.SetActive(true);
            TalkingText.text = "Oh.. You Found it! Now I can make a lantern and we can get out of here";
            quest1State = QuestState.TurnedIn;
            Debug.Log("Quest 1 Turned in");
            return;
        }
    }

    public void GiveQuestScene2()
    {
        if (quest2State == QuestState.NotGiven)
        {
            QuestManagerScene2.instance.StartQuest();
            quest2State = QuestState.Given;
            Debug.Log("Quest 2 Given");
        }
        else if (quest2State == QuestState.Given && QuestManagerScene2.instance.QuestIsCompleted == false)
        {
            TalkingPanel.SetActive(true);
            TalkingText.text = "Let's [Help RedBuzz and Defeat all BlueBolts]!";
            SingleTalkingLine = true;
        }
        else if (quest2State == QuestState.Given && QuestManagerScene2.instance.QuestIsCompleted == true)
        {
            QuestManagerScene2.instance.ClearedQuest();
            TalkingPanel.SetActive(true);
            TalkingText.text = "Phewww I thought we all going to die here.. Anyway! Let's countinue";
            quest2State = QuestState.TurnedIn;
            Debug.Log("Quest 2 Turned in");
        }
    }

    public void GiveQuestScene3()
    {
        if (quest3State == QuestState.NotGiven)
        {
            QuestManagerScene3.instance.StartQuest();
            quest3State = QuestState.Given;
            Debug.Log("Quest 3 Given");
        }
        else if (quest3State == QuestState.Given && QuestManagerScene3.instance.QuestIsCompleted == false)
        {
            TalkingPanel.SetActive(true);
            TalkingText.text = "Let's [Help RedBuzz and Defeat all BlueBolts]!";
            SingleTalkingLine = true;
        }
        else if (quest3State == QuestState.Given && QuestManagerScene3.instance.QuestIsCompleted == true)
        {
            QuestManagerScene2.instance.ClearedQuest();
            TalkingPanel.SetActive(true);
            TalkingText.text = "Phewww I thought we all going to die here.. Anyway! Let's countinue";
            quest3State = QuestState.TurnedIn;
            Debug.Log("Quest 2 Turned in");
        }
    }

}
