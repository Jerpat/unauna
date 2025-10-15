using UnityEngine;

public class Torch : Stuff, IInteractable
{
    public Torch() { 
        Name = "Torch";
    }
    public bool isInteractable { get => CanUse; set => CanUse = value; }

    public GameObject Firelight;
    public bool isOn;

    public override void SetUP()
    {
        base.SetUP();
        Firelight.gameObject.SetActive(isOn);
    }
    public void Interact(Player player)
    {
        isOn = !isOn;
        Firelight.gameObject.SetActive(isOn);
    }

   
}
