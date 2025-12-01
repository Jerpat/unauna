using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestManagerScene3 : MonoBehaviour
{
    //Set up
    public static QuestManagerScene3 instance; //
    public string LoadSceneName;
    public int currentQuest3Progress = 0;

    //Quest Text 
    public GameObject QuestPanel;
    public TMP_Text QuestText;
    public Slider Quest3ProgressBar;

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
        QuestText.text = "Quest: Kill Enemy and Fix the road?!"; //+ "(" + currentQuestProgress + "/3)";
        IsActive = true;
        Debug.Log("Quest 3 Started");
    }

    public void OnGoingQuest(int progress)
    {
        //Quest Info
        Quest3ProgressBar.value = currentQuest3Progress;
        currentQuest3Progress += progress;
        Debug.Log("Currently Quest: Kill Enemy and Fix the road?"); //
        if (IsActive == true && currentQuest3Progress > 0) //
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
        Debug.Log("Quest 3 Completed");
    }

}
