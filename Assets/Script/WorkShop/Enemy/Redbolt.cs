using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Redbolt : Enemy, IInteractable
{
    public bool canTalk = true;

    public bool isInteractable { get => canTalk; set => canTalk = value; }

    protected override void Update()
    {
        base.Update();

        if (player != null)
        {
            if (isChasing)
            {
                Chase(player);
            }
            else
            {
                agent.ResetPath();
            }
        }
    }

    /*public void Chase(Player _player)
    {
        //Vector3 destination = _player.transform.position;
        if (GetDistancePlayer() < seeRange && GetDistancePlayer() > atkRange)
        {
            agent.SetDestination(_player.transform.position);
        }
    }*/

    public void Interact(Player _player)
    {
        isChasing = true;
        Debug.Log($"{Name} start chasing {_player.Name}");
    }

    protected override void Attack(Player _player)
    {
        if (timer > 0)
        {
            return;
        }

        Collider[] hits = Physics.OverlapSphere(transform.position, atkRange);
        List<Character> ListTarget = new List<Character>();
        foreach (Collider hit in hits)
        {
            if (hit.gameObject != this.gameObject)
            {
                Buzzvenom c  = hit.GetComponent<Buzzvenom>();
                if (c != null) {
                    ListTarget.Add(c);
                }
                Player player = hit.GetComponent<Player>();
                if (player != null)
                {
                    ListTarget.Add(player);
                }
            }
        }
        
        Character Target = null;
        foreach (Character c in ListTarget)
        {
            float distacne = Vector3.Distance(transform.position, c.transform.position);
            float Targetdistacne = Vector3.Distance(transform.position, Target.transform.position);
            if (distacne < Targetdistacne) {
                Target = c;
            }
        }

        //MOVE TO TARGET

    }
}
