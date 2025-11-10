using UnityEngine;

public class BoxKinematic : Stuff, IInteractable
{
    public bool isInteractable { get => CanUse; set => CanUse = value; }

    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Interact(Player player)
    {
        if (!isInteractable)
        {
            return;
        }
        Debug.Log(isInteractable);

        _rb.isKinematic = !_rb.isKinematic;
    }
}
