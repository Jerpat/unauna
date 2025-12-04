using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGameManager : MonoBehaviour
{
    public static UIGameManager instance;

    private string currentScene;

    //Talking UI Setting
    public GameObject talkingPanel;
    public TMP_Text talkingText;
    public TMP_Text talkingNameText;

    //Quest UI Setting
    public GameObject questPanel;
    public TMP_Text questText;
    public Slider quest1Progressbar;
    public Slider quest2Progressbar;
    public Slider quest3Progressbar;

    public GameObject pausemenuUI;
    public TMP_Text hPText;
    public TMP_Text potionCountText;


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

    private void Update()
    {
        currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "01Dungeon" && QuestManagerScene1.instance.IsActive == true)
        {
            quest1Progressbar.gameObject.SetActive(true);
            quest2Progressbar.gameObject.SetActive(false);
            quest3Progressbar.gameObject.SetActive(false);
        }
        else if (currentScene == "02Desert" && QuestManagerScene2.instance.IsActive == true)
        {
            quest1Progressbar.gameObject.SetActive(false);
            quest2Progressbar.gameObject.SetActive(true);
            quest3Progressbar.gameObject.SetActive(false);
        }
        else if (currentScene == "03Forest" && QuestManagerScene3.instance.IsActive == true)
        {
            quest1Progressbar.gameObject.SetActive(false);
            quest2Progressbar.gameObject.SetActive(false);
            quest3Progressbar.gameObject.SetActive(true);
        }
    }
}
