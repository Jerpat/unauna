using UnityEngine;

public class TriggerLoadScene : Item
{
    public AudioClip BackgroundMusic;
    public string LoadSceneName;

    public override void OnCollected(Player player)
    {
        base.OnCollected(player);
        LoadSceneManager.instance.LoadNewScene(LoadSceneName);
        SoundManager.instance.PlayMusic(BackgroundMusic);
    }
}
