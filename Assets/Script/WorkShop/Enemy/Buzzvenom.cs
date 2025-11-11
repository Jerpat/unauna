using UnityEngine;

public class Buzzvenom : Enemy, IDestroyable
{
    protected override void Update()
    {
        base.Update();

        if (player != null && GetDistancePlayer() <= seeRange)
        {
            Chase(player);
        }
        else
        {
            GameObject _ally = GameObject.FindGameObjectWithTag("Ally");
            if (_ally != null)
            {
                Player _allyP = _ally.GetComponent<Player>();
                if (_allyP != null && Vector3.Distance(transform.position, _ally.transform.position) <= seeRange)
                {
                    Chase(_allyP);
                }
                else if (agent != null)
                {
                    agent.ResetPath();
                }
            }
            else if (agent != null)
            {
                agent.ResetPath();
            }
        }
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
            Character _target = null;

            if (hit.CompareTag("Player") || hit.CompareTag("Ally"))
            {
                _target = hit.GetComponent<Character>();
            }
            
            if (_target == null)
            {
                continue;
            }

            Turn(_target.transform.position - transform.position);

            if (agent != null)
            {
                agent.SetDestination(_target.transform.position);
            }

            _target.TakeDamage(Damage);
            animator.SetTrigger("Attack");
            Debug.Log($"{Name} attacks {_target.Name} for {Damage} damage.");
            timer = TimeToAttack;
            break;
        }
    }
}
