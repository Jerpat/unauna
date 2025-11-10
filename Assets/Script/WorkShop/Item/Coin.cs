using UnityEngine;

public class Coin : Item
{
    public int ScoreValue = 10;
    public AudioClip SoundCoin;
    public override void OnCollected(Player player)
    {
        base.OnCollected(player);
        GameManager.instance.AddScore(ScoreValue);
        SoundManager.instance.PlaySFX(SoundCoin);
        Destroy(gameObject);
    }
}
