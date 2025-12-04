using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenuManager : MonoBehaviour
{

    private string currentScene;

    //public static UIMenuManager instance;

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    public void Update()
    {
        Debug.Log("Test123");
        if (currentScene == "04Win")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Debug.Log("Test123");
        }
        else if (currentScene == "05Lose")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
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
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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

    //public void Win(bool o = false)
    //{
    //    Cursor.lockState = CursorLockMode.None;
    //    Cursor.visible = true;
    //    SceneManager.LoadScene(04);
    //}

    //public void Lose(bool Active = false)
    //{
    //    Cursor.lockState = CursorLockMode.None;
    //    Cursor.visible = true;
    //    SceneManager.LoadScene(05);
    //}
}
