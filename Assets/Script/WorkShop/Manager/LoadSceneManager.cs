using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    // 1. Singleton Instance
    public static LoadSceneManager instance;

    [Header("Loading Screen Reference")]
    public GameObject loadingScreenPanel;

    private string currentScene;

    // 3. Singleton Initialization
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

    // ------------------- Core Functionality -------------------

    private void Update()
    {
        currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "04Win")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Debug.Log("Test1");
        }

        if (currentScene == "05Lose")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Debug.Log("Test2");
        }
    }

    public void LoadNewScene(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }


    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        if (loadingScreenPanel != null)
        {
            loadingScreenPanel.SetActive(true);
        }
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            yield return null;
        }

        if (loadingScreenPanel != null)
        {
            loadingScreenPanel.SetActive(false);
        }

        //if (sceneName == "04Win")
        //{
        //    Cursor.lockState = CursorLockMode.None;
        //    Cursor.visible = true;
        //        Debug.Log("Test1");
        //}

        //if (sceneName == "05Lose")
        //{
        //    Cursor.lockState = CursorLockMode.None;
        //    Cursor.visible = true;
        //    Debug.Log("Test2");
        //}

        Debug.Log($"Scene '{sceneName}' loaded and activated successfully.");
    }

    public void HideLoadingScreen()
    {
        if (loadingScreenPanel != null)
        {
            loadingScreenPanel.SetActive(false);
        }
    }

    // ------------------- Utility -------------------

    public string GetCurrentSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

}