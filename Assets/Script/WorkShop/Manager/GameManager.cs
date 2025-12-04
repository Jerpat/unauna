using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


// กำหนดให้เป็น sealed เพื่อป้องกันการสืบทอด
public class GameManager : MonoBehaviour
{
    // 1. Private Static Field (The Singleton Instance = can be call from everywhere)
    public static GameManager instance;

    // 2. Public Static Property (Global Access Point)
   
    [Header("Game State")]
    public int currentScore = 0;
    public bool isGamePaused = false;

    [Header("UI Game")]
    public GameObject pauseMenuUI;
    public TMP_Text scoreText;
    public TMP_Text HPText;
    public Slider HPBar;

    // 3. Private Constructor Logic (ใช้ Awake() แทน Constructor ปกติใน Unity)
    private void Awake() // since instance can have more than 1, this pattern is to not create more
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
       
    }

    // ------------------- Singleton Functionality -------------------

    public void UpdateHealthText(int health)
    {
        //Debug.Log("HP : " + health);
        HPText.text = "HP : " + " " + health.ToString();
    }
    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        HPBar.value = currentHealth;
        HPBar.maxValue = maxHealth;
    }
    public void AddScore(int amount)
    {
        currentScore += amount;
        scoreText.text = currentScore.ToString();
    }

    public void TogglePause()
    {
        Debug.Log("Game is Paused");
        isGamePaused = !isGamePaused;
        Time.timeScale = isGamePaused ? 0:1; //everything pause if time = 0
        pauseMenuUI.SetActive(isGamePaused);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Update()
    {
        //UI Setting
        pauseMenuUI = UIGameManager.instance.pausemenuUI;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TogglePause();
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        HPText = GameObject.Find("HPText")?.GetComponent<TMP_Text>();
        HPBar = GameObject.Find("HPBar")?.GetComponent<Slider>();
        scoreText = GameObject.Find("ScoreText")?.GetComponent<TMP_Text>();
        pauseMenuUI = GameObject.Find("PauseMenuUI");

        Debug.Log("UI linked on scene: " + scene.name);
        Debug.Log("HPText = " + HPText);
    }
}