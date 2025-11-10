using UnityEngine;

public class BoxDrop : Stuff, IInteractable
{
    public bool isInteractable { get => CanUse; set => CanUse = value; }

    public GameObject ItemDrop;

    public void Interact(Player player)
    {
        if (!isInteractable)
        {
            return;
        }
        Debug.Log(isInteractable);

        if (ItemDrop != null)
        {
            ItemDrop.SetActive(true);
        }

        Debug.Log("Box has destroyed, Item dropped");
        Destroy(gameObject);
    }
}
