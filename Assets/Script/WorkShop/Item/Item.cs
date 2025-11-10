using UnityEngine;

[RequireComponent(typeof(SphereCollider))] //auto insert collider
public class Item : Identity
{
    private Collider _collider; //child  can reach this
    protected Collider itemcollider {
        get {
            if (_collider == null) {
                _collider = GetComponent<Collider>();
                _collider.isTrigger = true;
            }
            return _collider;
        }
    }

    public override void SetUP() {
        base.SetUP();
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
    }
    public Item() { 
    }
    public Item(Item item)
    {
        this.Name = item.Name;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") { 
            OnCollected(player);
        }
    }
    public virtual void OnCollected(Player player) { 
        Debug.Log($"Collected {Name}");
    }
    public virtual void Use(Player player)
    {
        Debug.Log($"Using {Name}");
    }
}
