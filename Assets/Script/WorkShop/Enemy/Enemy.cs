using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public abstract class Enemy : Character
{
    protected enum State { idle, run, attack, death }

    protected NavMeshAgent agent;

    [SerializeField] //show in inspector even it is private
    protected float seeRange = 10f;
    [SerializeField]
    protected float atkRange = 5f;

    protected float TimeToAttack = 1f;
    protected float timer = 0f;

    protected State currentState = State.idle;


    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            agent = gameObject.AddComponent<NavMeshAgent>();
            agent.stoppingDistance = 2.0f;
        }

        if (animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }

        if (animator == null)
        {
            Debug.LogWarning("Animator not found on " + gameObject.name);
        }
    }

    public override void SetUP()
    {
        base.SetUP();

    }
    protected virtual void Update()
    { 
        timer -= Time.deltaTime;

        if(player == null)
        {
            idleState();
            return;
        }

        if (GetDistancePlayer() > seeRange)
        {
            idleState();
        }
        else if (GetDistancePlayer() <= seeRange && GetDistancePlayer() > atkRange)
        {
            Turn(player.transform.position - transform.position);
            Chase(player);
        }
        else
        {
            agent.ResetPath();
            Attack(player);
        }
    }

    protected void idleState()
    {
        agent?.ResetPath();
        if (animator != null)
        {
            animator.SetBool("Attack", false);
        }
    }

    protected override void Turn(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = lookRotation;
    }

    protected void Chase(Player _player)
    {
        if (_player == null) return;
        agent.SetDestination(_player.transform.position);
        animator.SetBool("Attack", false);
    }

    protected virtual void Attack(Player _player)
    {
        if(timer > 0 || player == null) return;

        agent.ResetPath();
        Turn(_player.transform.position - transform.position);
        _player.TakeDamage(Damage);
        animator.SetBool("Attack", true);
        Debug.Log($"{Name} attacks {_player.Name} for {Damage} damage.");
        timer = TimeToAttack;
    }

    //Move to enemy that according to the scene
    public override void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            if (gameObject.name == "Buzzvenom")
            {
                QuestManagerScene2.instance.OnGoingQuest(1);
            }
            Destroy(gameObject);
            SoundManager.instance.PlaySFX(SoundManager.instance.dieEnemySFX);
        }
        else
        {
            SoundManager.instance.PlaySFX(SoundManager.instance.hitEnemySFX);
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
