using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Default Audio Clips")]
    public AudioClip defaultButtonClick;
    public AudioClip defaultBackgroundMusic;

    [Header("Footstep Sounds")]
    public AudioClip grassStep;
    public AudioClip sandStep;
    public AudioClip stoneStep;
    public AudioClip waterStep;

    [Header("Footstep Settings")]
    public float walkInterval = 0.4f;
    public float runInterval = 0.25f;

    private float stepTimer = 0f;

    [Header("SFX")]
    public AudioClip hitEnemySFX;
    public AudioClip dieEnemySFX;
    public AudioClip healSFX;

    private string currentScene;

    private void Update()
    {
        currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "01Dungeon")
        {
            defaultBackgroundMusic = GameObject.Find("ambDungeon")?.GetComponent<AudioClip>();
        }
        else if (currentScene == "02Desert")
        {
            defaultBackgroundMusic = GameObject.Find("ambDesert")?.GetComponent<AudioClip>();
        }
        else if (currentScene == "03Forest")
        {
            defaultBackgroundMusic = GameObject.Find("ambForest")?.GetComponent<AudioClip>();
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            musicSource = gameObject.AddComponent<AudioSource>();
            sfxSource = gameObject.AddComponent<AudioSource>();

            musicSource.loop = true;
            musicSource.volume = 0.2f;
            PlayMusic(defaultBackgroundMusic);

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip == null) return;
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;
        sfxSource.PlayOneShot(clip);
    }

    public void PlayFootstep(string groundType, bool isRunning)
    {
        stepTimer -= Time.deltaTime;
        if (stepTimer > 0) return;

        AudioClip clip;

        if (groundType == "Grass")
        {
            clip = grassStep;
        }
        else if (groundType == "Sand")
        {
            clip = sandStep;
        }
        else if (groundType == "Stone")
        {
            clip = stoneStep;
        }
        else if (groundType == "Water")
        {
            clip = waterStep;
        }
        else
        {
            clip = grassStep;
        }

        sfxSource.PlayOneShot(clip);
        sfxSource.volume = 0.15f;

        if (isRunning)
        {
            stepTimer = runInterval;
        }
        else
        {
            stepTimer = walkInterval;
        }
    }
}
