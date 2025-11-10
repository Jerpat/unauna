using UnityEngine;

public class Torch : Stuff, IInteractable
{
    public bool isInteractable { get => CanUse; set => CanUse = value; }

    public bool isOn;
    public GameObject FireLight;

    public override void SetUP()
    {
        base.SetUP();
        FireLight.SetActive(isOn);
    }
    public void Interact(Player player)
    {
        if (!isInteractable)
        {
            return;
        }
        Debug.Log(isInteractable);

        isOn = !isOn; // short ver
        FireLight.SetActive(isOn);

        /*if(isOn == true)
        {
            isOn = false;
        }
        else
        {
            isOn = true; 
        }*/ // long ver
    }
}
