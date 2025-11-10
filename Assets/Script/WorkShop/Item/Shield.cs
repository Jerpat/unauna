using UnityEngine;

public class Shield : Item
{
    float x = 0.08f;
    public override void OnCollected(Player mPlayer)
    {
        base.OnCollected(mPlayer);
        transform.parent = mPlayer.LeftHand; // transform shield to be hands child
        transform.localPosition = Vector3.zero;
        itemcollider.enabled = false;

        Vector3 shieldUpR = new Vector3(0, -90, 180);
        transform.localRotation = Quaternion.Euler(shieldUpR); // rotate shield to right angle

        Vector3 shieldUpP = new Vector3(-x, 0, 0);
        transform.localPosition = shieldUpP; // right position
    }
}
