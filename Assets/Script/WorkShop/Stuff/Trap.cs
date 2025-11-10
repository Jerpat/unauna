using UnityEngine;

public class Trap : Stuff, IInteractable
{
    public bool isInteractable { get => CanUse; set => CanUse = value; }
    
    public GameObject spikes;

    public void Interact(Player player)
    {
        if (!isInteractable)
        {
            return;
        }
        Debug.Log(isInteractable);

        _collider = GetComponent<Collider>();
        _collider.enabled = false;
        spikes.SetActive(false);
        isInteractable = false;
        Debug.Log("Trap activated");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.TakeDamage(10);
        }
    }
}
