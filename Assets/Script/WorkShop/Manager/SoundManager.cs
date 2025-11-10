using UnityEngine;
using System.Collections.Generic;

// กำหนดให้เป็น sealed เพื่อป้องกันการสืบทอด
public class SoundManager : MonoBehaviour
{
    // 1. Singleton Instance
    public static SoundManager instance;

    [Header("Audio Sources")]
    // Audio Source สำหรับเพลงประกอบ (Looping)
    public AudioSource musicSource;
    // Audio Source สำหรับเอฟเฟกต์เสียง (Non-Looping)
    public AudioSource sfxSource;

    [Header("Default Audio Clips")]
    public AudioClip defaultButtonClick;
    public AudioClip defaultBackgroundMusic;

    // 3. Singleton Initialization
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            musicSource = gameObject.AddComponent<AudioSource>();
            sfxSource = gameObject.AddComponent<AudioSource>();

            musicSource.loop = true;
            musicSource.volume = 0.3f;
            PlayMusic(defaultBackgroundMusic);

            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // ------------------- Music Controls -------------------

    /// <summary>
    /// เล่นเพลงประกอบใหม่
    /// </summary>
    public void PlayMusic(AudioClip clip)
    {
        if (clip == null || musicSource == null) return;

        musicSource.clip = clip;
        musicSource.Play();
    }

    public void StopMusic()
    {
        if (musicSource != null)
        {
            musicSource.Stop();
        }
    }

    // ------------------- SFX Controls -------------------

    /// <summary>
    /// เล่นเอฟเฟกต์เสียงแบบครั้งเดียวจบ (One-Shot)
    /// </summary>
    public void PlaySFX(AudioClip clip)
    {
        if (clip == null || sfxSource == null) return;

        // ใช้ PlayOneShot เพื่อให้เล่นหลายเสียงทับซ้อนกันได้
        sfxSource.PlayOneShot(clip);
    }

    // ------------------- Volume Controls -------------------

    /// <summary>
    /// กำหนดระดับเสียงหลักของเพลงประกอบ (0.0 ถึง 1.0)
    /// </summary>
    public void SetMusicVolume(float volume)
    {
        if (musicSource != null)
        {
            musicSource.volume = volume;
        }
    }

    /// <summary>
    /// กำหนดระดับเสียงหลักของเอฟเฟกต์เสียง (0.0 ถึง 1.0)
    /// </summary>
    public void SetSFXVolume(float volume)
    {
        if (sfxSource != null)
        {
            sfxSource.volume = volume;
        }
    }
}