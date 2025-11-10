using UnityEngine;

public class Potion : Item
{
    public int healAmount = 20;
    public override void OnCollected(Player player)
    {
        base.OnCollected(player); // debug already cellected potion
        player.Heal(healAmount);
        Destroy(gameObject);
    }
}
