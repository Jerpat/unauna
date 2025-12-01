using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuManager : MonoBehaviour
{
    //Start Game
    public void OnStartGameClicked()
    {
        //SceneManager.LoadScene(1);
        SceneManager.LoadScene(7);
        Debug.Log("Starting the game");
    }

    //Exit Back to Home
    public void BackToHomeClicked()
    {
        //SceneManager.LoadScene(0);
        SceneManager.LoadScene(5);
        Debug.Log("Back to Home Scene");
    }

    public void BackFromPause()
    {
        GameManager.instance.TogglePause();
    }

    //Quit Game
    public void OnExitClicked()
    {
        Application.Quit();
        Debug.Log("Quit the game");
    }
}
