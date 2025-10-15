using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Box : Stuff
{
    public Box() {
        Name = "Box";
    }
    public GameObject DropItem;
    public bool isInteractable { get => CanUse; set => CanUse=value; }

    private int _health;
    private int _maxHealth = 25;


}
