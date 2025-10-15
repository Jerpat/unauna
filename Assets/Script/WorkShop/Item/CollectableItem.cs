using UnityEngine;

public class CollectableItem : Item
{
    public int value = 10;
    public CollectableItem(CollectableItem item) : base(item)
    {
        value = item.value;
    }
    public override void OnCollect(Player player)
    {
        base.OnCollect(player);
        player.AddItem(this);
        gameObject.SetActive(false);
    }

}
