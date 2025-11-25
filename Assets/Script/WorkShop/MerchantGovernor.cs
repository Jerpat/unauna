using TMPro;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MerchantGovernor : Character, IInteractable, ITalkable
{
    //SetUp
    public static MerchantGovernor instance;
    public bool canTalk = true;
    public bool canInteract = true;
    private bool Quest1 = false;

    //Interact Text
    public TMP_Text interactionTextUI;

    //Talking Conversations Text 
    public GameObject TalkingPanel;
    public TMP_Text TalkingText;
    public string[] TalkingLines;
    private int index = 0;

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

    public bool isInteractable { get => canInteract; set => canInteract = value; }
    public bool isTalkable { get => canTalk; set => canTalk = value; }


    public override void SetUP()
    {
        //DontDestroyOnLoad(gameObject);
        //TalkingPanel = GetComponentInChildren<GameObject>();
        //TalkingText = GetComponentInChildren<TMP_Text>();

        interactionTextUI = GetComponentInChildren<TMP_Text>();

        //UI Setting
        TalkingPanel.gameObject.SetActive(false);
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
        Talk(player);
        Debug.Log("Interact With Merchant Governor");
    }
    public void Talk(Player player)
    {
        //UI Setting
        TalkingPanel.gameObject.SetActive(true);

        if (index < TalkingLines.Length)
        {
            TalkingText.text = TalkingLines[index];
            index++;

        }
        else
        {
            TalkingPanel.gameObject.SetActive(false);
            GiveQuestScene2();
            Debug.Log("Conversation Ended");
        }

    }

    public void GiveQuestScene1()
    {
        QuestManagerScene1.instance.StartQuest();
        Quest1 = true;
        Debug.Log("Quest Scene 1 Given");
    }

    public void GiveQuestScene2()
    {
        QuestManagerScene2.instance.StartQuest();
        Debug.Log("Quest Scene 2 Given");
    }

    //public void GiveRewardScene1()
    //{
    //    if Talk
    //    Debug.Log("Reward Scene 1 Given");
    //    TalkingText.text = TalkingLines[6];
    //    QuestManagerScene1.instance.ClearedQuest();
    //    LoadSceneManager.instance.LoadNewScene(LoadScene1Name);
    //}
}
