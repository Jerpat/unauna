using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenuManager : MonoBehaviour
{
    public static UIMenuManager instance;

    public GameObject talkingPanel;
    public TMP_Text talkingText;
    public TMP_Text talkingNameText;

    public GameObject questPanel;
    public TMP_Text questText;
    public Slider quest2ProgressBar;
    public Slider quest3ProgressBar;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //Start Game
    public void OnStartGameClicked()
    {
        SceneManager.LoadScene(01);
        Debug.Log("Starting the game");
    }

    //Exit Back to Home
    public void BackToHomeClicked()
    {
        SceneManager.LoadScene(00);
        Debug.Log("Back to Home Scene");
    }

    public void BackFromPause()
    {
        GameManager.instance.TogglePause();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    //Quit Game
    public void OnExitClicked()
    {
        Application.Quit();
        Debug.Log("Quit the game");
    }
}
