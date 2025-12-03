using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestManagerScene3 : MonoBehaviour
{
    //Set up
    public static QuestManagerScene3 instance; 
    public int currentQuest3Progress = 0;
    public GameObject BarrierWall3;

    //Quest Text 
    public GameObject QuestPanel;
    public TMP_Text QuestText;
    public Slider Quest3ProgressBar;

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
        QuestPanel = UIMenuManager.instance.questPanel;
        QuestText = UIMenuManager.instance.questText;
        Quest3ProgressBar = UIMenuManager.instance.quest3ProgressBar;
        QuestPanel.gameObject.SetActive(false);
    }

    public void StartQuest()
    {
        //Quest UI Setting
        QuestPanel.gameObject.SetActive(true);
        QuestText.text = "Quest: Kill [Monster] and Take [A Key]"; //+ "(" + currentQuestProgress + "/3)";
        IsActive = true;
        Debug.Log("Quest 3 Started");
    }

    public void OnGoingQuest(int progress)
    {
        //Quest Info
        Quest3ProgressBar.value = currentQuest3Progress;
        currentQuest3Progress += progress;
        Debug.Log("Currently Quest: Find A Key that drop from Monster"); //
        if (IsActive == true && currentQuest3Progress > 0) //
        {

            //QuestText.text = "Quest: Completed! (Talk to Merchant Governor to countinue)";
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
        Debug.Log("Quest 3 Completed");
        //MerchantGovernor.instance.GiveRewardScene1();
    }

    public void ClearedQuest()
    {
        QuestPanel.gameObject.SetActive(false);
        BarrierWall3.gameObject.SetActive(false);
        //LoadSceneManager.instance.LoadNewScene(LoadScene3Name);
    }
}
