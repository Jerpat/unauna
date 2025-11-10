using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // สำคัญมากสำหรับ Scene Management

public class LoadSceneManager : MonoBehaviour
{
    // 1. Singleton Instance
    public static LoadSceneManager instance;

    [Header("Loading Screen Reference")]
    public GameObject loadingScreenPanel; // อ้างอิงถึง Panel ที่ใช้เป็นหน้าจอโหลด

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

    /// <summary>
    /// เมธอดหลักสำหรับโหลดฉากใหม่แบบซิงโครนัส
    /// </summary>
    public void LoadNewScene(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    /// <summary>
    /// Coroutine หลักสำหรับการโหลดฉากแบบ Asynchronous
    /// </summary>
    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        // 1. เตรียมการโหลด
        if (loadingScreenPanel != null)
        {
            loadingScreenPanel.SetActive(true); // แสดงหน้าจอโหลด
        }

        // 2. เริ่มการโหลดแบบ Asynchronous
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        // ป้องกันไม่ให้ฉากใหม่แสดงจนกว่าจะถูกสั่ง
        // (มีประโยชน์เมื่อคุณต้องการให้ฉากเก่าซ่อนหายไปก่อน หรือรอจนกว่าโหลดเสร็จ 90% แล้วค่อยสั่ง)
        // operation.allowSceneActivation = false; 

        // 3. วนลูปตรวจสอบความคืบหน้า
        while (!operation.isDone)
        {
            // operation.progress มีค่าตั้งแต่ 0.0 ถึง 0.9 (เมื่อพร้อมจะเปลี่ยนฉาก)
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            // รอหนึ่งเฟรมก่อนตรวจสอบซ้ำ
            yield return null;
        }

        // 4. สิ้นสุดการโหลด
        // ในขั้นตอนนี้ operation.isDone เป็น true แล้ว (100% เสร็จสมบูรณ์)

        // 5. ซ่อนหน้าจอโหลด
        if (loadingScreenPanel != null)
        {
            loadingScreenPanel.SetActive(false);
        }

        Debug.Log($"Scene '{sceneName}' loaded and activated successfully.");
    }

    /// <summary>
    /// เมธอดสำหรับซ่อนหน้าจอโหลด (อาจถูกเรียกจากฉากใหม่)
    /// </summary>
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