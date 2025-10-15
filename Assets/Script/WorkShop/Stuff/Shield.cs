using UnityEngine;

public class Shield : Stuff, IInteractable
{
 
    public GameObject shieldMesh;
    public int Deffent = 10;
    public bool isInteractable { get => CanUse; set => CanUse = value; }
    public void Interact(Player player)
    {
        if (isInteractable == true) {
            Vector3 ShielddUp = new Vector3(0, 0, 180);
            shieldMesh.transform.parent = player.LeftHand;
            shieldMesh.transform.localPosition = Vector3.zero;
            shieldMesh.transform.localRotation = Quaternion.Euler(ShielddUp);
            player.Deffent += Deffent;
            isInteractable = false;
        }

    }
}
