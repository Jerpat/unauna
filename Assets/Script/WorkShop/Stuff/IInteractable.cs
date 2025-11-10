using UnityEngine;
using TMPro;
public interface IInteractable
{
    // check if interact or not
    bool isInteractable { get; set; }

    // function works when interacted
    void Interact(Player player);

}
