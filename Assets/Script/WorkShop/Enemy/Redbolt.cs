using UnityEngine;

public class Redbolt : Enemy, IInteractable, IChaseable
{
    public bool canTalk = true;

    public bool isInteractable { get => canTalk; set => canTalk = value; }

    public void Chase(Player _player)
    {
        Vector3 destination = _player.transform.position;
        if (GetDistancePlayer() < seeRange && GetDistancePlayer() > atkRange)
        {
            agent.SetDestination(destination);
            Debug.Log($"{Name} start chasing {_player.Name}");
        }
    }

    public void Interact(Player _player)
    {
        
    }

}
