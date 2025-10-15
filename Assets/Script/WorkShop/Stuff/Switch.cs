using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Switch : Stuff
{
    public Switch() { 
        Name = "Switch";
    }
    public bool isInteractable { get => CanUse; set => CanUse = value; }
    [SerializeField]
    bool isOn = false;
    Animator animator;
    public Identity InteracTo;
}

