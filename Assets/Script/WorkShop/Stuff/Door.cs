using System.Collections;
using TMPro;
using UnityEngine;

public class Door : Stuff
{
    public Door() {
        Name = "Door";
    }
    private bool isOpen = false;
    public Vector3 openOffset = new Vector3(0, 0, 2f);

    public float slideSpeed = 2f;
    public Transform door;

    public bool isInteractable { get => CanUse; set => CanUse = value; }

    public void Interact(Player player)
    {
       

        isOpen = !isOpen;
    }

    private IEnumerator SlideDoor(Vector3 targetPosition)
    {
        Vector3 startPosition = door.position;
        float timeElapsed = 0;

        yield return null;
        door.position = targetPosition;
    }

}
