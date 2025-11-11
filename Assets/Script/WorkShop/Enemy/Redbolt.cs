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
        foreach (Collider hit in hits)
        {
            Character _enemy = null;
            if (hit.CompareTag("Enemy") && hit.gameObject != this.gameObject)
            {
                _enemy = hit.GetComponent<Character>();
                if (_enemy != null)
                {
                    Turn(_enemy.transform.position - transform.position);

                    if(agent != null)
                    {
                        agent.SetDestination(_enemy.transform.position);
                    }

                    _enemy.TakeDamage(Damage);
                    animator.SetTrigger("Attack");
                    Debug.Log($"{Name} attacks {_enemy.Name} for {Damage} damage.");
                    timer = TimeToAttack;
                    break;
                }
            }
        }
    }
}
