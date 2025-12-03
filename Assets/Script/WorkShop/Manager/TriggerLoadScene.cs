using UnityEngine;

public class TriggerLoadScene : Item
{
    public string LoadSceneName;

    public override void OnCollected(Player player)
    {
        base.OnCollected(player);
        LoadSceneManager.instance.LoadNewScene(LoadSceneName);

        if (gameObject.name == "Gate")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
