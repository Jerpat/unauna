using UnityEngine;

public class Potion : Item
{
    public int healAmount = 20;

    public AudioClip collectPotionSFX;
    /*public override void OnCollected(Player player)
    {
        base.OnCollected(player); // debug already cellected potion
        player.Heal(healAmount);
        Destroy(gameObject);
    }*/
    public override void OnCollected(Player player)
    {
        base.OnCollected(player);
        player.AddItem(this);
        player.UpdatePotionUI();
        gameObject.SetActive(false);
        SoundManager.instance.PlaySFX(collectPotionSFX);

    }
}
