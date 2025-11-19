using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyPatrol : Character
{
    protected enum State { idle, chase, attack, death, patrol }

    protected NavMeshAgent agent;

    [SerializeField] //show in inspector even it is private
    protected float seeRange = 10f;
    [SerializeField]
    protected float atkRange = 5f;

    protected float TimeToAttack = 1f;
    protected float timer = 0f;

    [Header("Enemy Behavior")]
    public bool isReturnToOrigin = false;
    private Transform originPos;

    public bool isPatrol = false;
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;

    protected State currentState = State.idle;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            agent = gameObject.AddComponent<NavMeshAgent>();
            agent.stoppingDistance = 2.0f;
        }
        originPos = new GameObject($"{name}_Origin").transform;
        originPos.position = transform.position;
    }

    protected virtual void Update()
    {
        timer -= Time.deltaTime;

        /*if (player == null)
        {
            patrolState();
            return;
        }*/

        if (GetDistancePlayer() > seeRange)
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

        if (GetDistancePlayer() <= seeRange && GetDistancePlayer() > atkRange)
        {
            Turn(player.transform.position - transform.position);
            Chase(player);
            return;
        }
        else
        {
            agent.ResetPath();
            Attack(player);
        }
    }

    protected virtual void idleState()
    {
        agent.ResetPath();
        animator.SetBool("Attack", false);
    }

    protected virtual void patrolState()
    {
        if (!isPatrol || waypoints.Length == 0)
        {
            idleState();
            return;
        }

        Transform wp = waypoints[currentWaypointIndex];
        agent.SetDestination(wp.position);
        animator.SetBool("Attack", false);

        if (Vector3.Distance(transform.position, wp.position) < 4f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
    }

    protected override void Turn(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = lookRotation;
        //transform.rotation = Quaternion.LookRotation(direction); short ver
    }

    protected void Chase(Player _player)
    {
        if (_player == null) return;
        agent.SetDestination(_player.transform.position);
        animator.SetBool("Attack", false);
    }

    protected virtual void Attack(Player _player)
    {
        if (timer > 0) return;

        Turn(_player.transform.position - transform.position);
        _player.TakeDamage(Damage);
        animator.SetBool("Attack", true);
        Debug.Log($"{Name} attacks {_player.Name} for {Damage} damage.");
        timer = TimeToAttack;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, atkRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, seeRange);
        Gizmos.color = Color.blue;
        for(int i = 0; i < waypoints.Length; i++)
        {
            Gizmos.DrawWireSphere(waypoints[i].position, 0.3f);
            if(i < waypoints.Length - 1)
            {
                Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
            }
        }
    }
}
