using UnityEngine;

public class CollectableItem : Item
{
    public int value = 10;
    public CollectableItem(CollectableItem item) : base(item)
    {
        value = item.value;
    }
    public override void OnCollected(Player player)
    {
        base.OnCollected(player);
        player.AddItem(this);
        gameObject.SetActive(false);
        if (gameObject.name == "Glowing_Crystal")
        {
            QuestManagerScene1.instance.OnGoingQuest(1);
        }
        if (gameObject.name == "A_Key")
        {
            QuestManagerScene3.instance.OnGoingQuest(1);
        }
    }

}
