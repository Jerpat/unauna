using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    protected enum State { idle, chase, attack, death }

    protected NavMeshAgent agent;

    [SerializeField] //show in inspector even it is private
    protected float seeRange = 10f;
    [SerializeField]
    protected float atkRange = 5f;
    private float TimeToAttack = 1f;
    protected float timer = 0f;

    protected State currentState = State.idle;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    { 
        if (player == null)
        {
            animator.SetBool("Attack", false);
            return;
        }

        timer -= Time.deltaTime;

        if(GetDistancePlayer() <= seeRange)
        {
            Turn(player.transform.position - transform.position);
        }

        if (GetDistancePlayer() <= atkRange)
        {
            Attack(player);
        }
        /*else
        {
            animator.SetBool("Attack", false);
            agent.ResetPath();
        }*/
    }

    protected override void Turn(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = lookRotation;
    }

    protected virtual void Follows(Player _player)
    {
        Vector3 destination = player.transform.position;
        if(GetDistancePlayer() < seeRange && GetDistancePlayer() > atkRange)
        {
            agent.SetDestination(destination);
            Debug.Log($"{Name} start following");
        }
    }

    protected virtual void Attack(Player _player)
    {
        if (timer <= 0)
        {
            _player.TakeDamage(Damage);
            animator.SetBool("Attack", true);
            Debug.Log($"{Name} attacks {_player.Name} for {Damage} damage.");
            timer = TimeToAttack;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, atkRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, seeRange);
    }
}
