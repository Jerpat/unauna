using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    public Slider HPBar;

    // 3. Private Constructor Logic (ใช้ Awake() แทน Constructor ปกติใน Unity)
    private void Awake() // since instance can have more than 1, this pattern is to not create more
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
       
    }

    // ------------------- Singleton Functionality -------------------

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
        isGamePaused = !isGamePaused;
        Time.timeScale = isGamePaused ? 0:1; //everything pause if time = 0
        pauseMenuUI.SetActive(isGamePaused);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
}