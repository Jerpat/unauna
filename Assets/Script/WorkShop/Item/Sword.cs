using UnityEngine;

public class Sword : Item
{
    public int Damage = 25;
    public Sword(Sword sword) : base(sword)
    {
        Damage = sword.Damage;
    }
    public override void OnCollect(Player player)
    {
        base.OnCollect(player);
        Vector3 swordUp = new Vector3(90, 0, 0);
        itemcollider.enabled = false;
        transform.parent = player.RightHand;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(swordUp);
        player.Damage += Damage;
    }
    
}
