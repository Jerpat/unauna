using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Sword : Item
{
    public int Damage = 25;
    public Sword(Sword sword) : base(sword)
    {
        Damage = sword.Damage;
    }
    public override void OnCollected(Player player)
    {
        base.OnCollected(player);

        if (player.currentWeapon != null)
        {
            player.Damage -= player.currentWeapon.Damage; // reset damage of old item
            Destroy(player.currentWeapon.gameObject); // destroy old item
        }

        transform.parent = player.RightHand; // transform item to be hands child
        transform.localPosition = Vector3.zero;
        itemcollider.enabled = false;

        Vector3 swordUp = new Vector3(90, 0, 0);
        transform.localRotation = Quaternion.Euler(swordUp); // rotate item to right angle

        player.Damage += Damage;

        player.currentWeapon = this; //save this to current weapon
    }

}
