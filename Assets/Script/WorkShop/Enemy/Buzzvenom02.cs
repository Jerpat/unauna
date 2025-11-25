using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Buzzvenom02 : EnemyPatrol, IDestroyable
{
    protected override void Update()
    {
        //base.Update();
        timer -= Time.deltaTime;

        Character closestT = FindClosestTarget<Player, Redbolt>();

        if (closestT == null)
        {
            patrolState();
            return;
        }

        float distance = Vector3.Distance(transform.position, closestT.transform.position);

        if (distance > seeRange)
        {
            animator.SetBool("Attack", false);
            if (isReturnToOrigin)
            {
                agent.SetDestination(originPos.position);
            }
            else
            {
                patrolState();
            }
            return;
        }


        if (closestT != null)
        {
            if (distance > atkRange)
            {
                agent.SetDestination(closestT.transform.position);
                animator.SetBool("Attack", false);
            }
            else
            {
                agent.ResetPath();
                Attack(null);
            }
        }


        /*if (player != null && GetDistancePlayer() <= seeRange)
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
        }*/
        /*if (player != null && GetDistancePlayer() <= seeRange)
        {
            if (GetDistancePlayer() > atkRange)
            {
                agent.SetDestination(player.transform.position);
                animator.SetBool("Attack", false);
            }
            else
            {
                agent.ResetPath();
                Attack(player);
            }
        }
        else
        {
            idleState();
        }*/
    }
    protected Character FindClosestTarget<T1, T2>()
        where T1 : Character
        where T2 : Character

    {
        Collider[] hits = Physics.OverlapSphere(transform.position, seeRange);
        Character closest = null;
        float minDist = Mathf.Infinity;

        foreach (var hit in hits)
        {
            if (hit.gameObject == this.gameObject) continue;

            Character t = null;

            T1 p = hit.GetComponent<T1>();
            if (p != null) t = p;

            T2 r = hit.GetComponent<T2>();
            if (r != null) t = r;

            if (t != null)
            {
                float dist = Vector3.Distance(transform.position, t.transform.position);
                if (dist < minDist)
                {
                    minDist = dist;
                    closest = t;
                }
            }
        }
        return closest;
    }

    protected override void Attack(Player _player)
    {
        if (timer > 0) return;

        /*Collider[] hits = Physics.OverlapSphere(transform.position, seeRange);
        List<Character> ListTarget = new List<Character>();
        foreach (Collider hit in hits)
        {
            if (hit.gameObject != this.gameObject)
            {
                Redbolt c = hit.GetComponent<Redbolt>();
                if (c != null)
                {
                    ListTarget.Add(c);
                }
                Player player = hit.GetComponent<Player>();
                if (player != null)
                {
                    ListTarget.Add(player);
                }
            }
        }

        Character _target = null;
        float targetDistance = Mathf.Infinity;

        foreach (Character c in ListTarget)
        {
            float distacne = Vector3.Distance(transform.position, c.transform.position);
            //float Targetdistacne = Vector3.Distance(transform.position, _target.transform.position);
            if (distacne < targetDistance)
            {
                targetDistance = distacne;
                _target = c;
                agent.SetDestination(_target.transform.position);
            }
        }*/

        Character _target = FindClosestTarget<Player, Redbolt>();

        if (_target != null)
        {
            Turn(_target.transform.position - transform.position);
            agent.SetDestination(_target.transform.position);

            _target.TakeDamage(Damage);
            animator.SetTrigger("Attack");
            Debug.Log($"{Name} attacks {_target.Name} for {Damage} damage.");
            timer = TimeToAttack;
        }
    }
}
