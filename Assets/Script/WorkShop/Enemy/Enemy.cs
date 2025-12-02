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

    public GameObject FloatingTextPrefab;

    protected void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            agent = gameObject.AddComponent<NavMeshAgent>();
            agent.stoppingDistance = 2.0f;
        }
        /*agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 2.0f;*/
    }

    public override void SetUP()
    {
        base.SetUP();

    }
    protected virtual void Update()
    { 
        /*if (player == null)
        {
            animator.SetBool("Attack", false);
            return;
        }*/

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
            //agent.SetDestination(player.transform.position);
            Turn(player.transform.position - transform.position);
            Chase(player);
        }
        else
        {
            agent.ResetPath();
            Attack(player);
        }
        /*else
        {
            Chase(player);
        }*/
        /*else
        {
            animator.SetBool("Attack", false);
            agent.ResetPath();
        }*/
    }

    protected void idleState()
    {
        agent.ResetPath();
        animator.SetBool("Attack", false);
    }

    protected override void Turn(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = lookRotation;
    }

    protected void Chase(Player _player)
    {
        //Vector3 destination = _player.transform.position;
        /*if (GetDistancePlayer() < seeRange && GetDistancePlayer() > atkRange)
        {
            agent.SetDestination(_player.transform.position);
        }*/
        if (_player == null) return;
        agent.SetDestination(_player.transform.position);
        animator.SetBool("Attack", false);
    }

    protected virtual void Attack(Player _player)
    {
        /*if (timer < 0)
        {
            _player.TakeDamage(Damage);
            animator.SetBool("Attack", true);
            Debug.Log($"{Name} attacks {_player.Name} for {Damage} damage.");
            timer = TimeToAttack;
        }*/

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
            //SoundManager.instance.PlaySFX(SoundDefeat);
            Destroy(gameObject);
        }
        else
        {
            SoundManager.instance.PlaySFX(SoundManager.instance.hitEnemySFX);
            ShowFloatingText();
        }
    }

    void ShowFloatingText()
    {
        Debug.Log("SPAWN FLOATING TEXT");

        Vector3 pos = transform.position + new Vector3(0, 2f, 0);
        var obj = Instantiate(FloatingTextPrefab, pos, Quaternion.identity);

        if (obj == null)
            Debug.Log("INSTANTIATE FAILED");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, atkRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, seeRange);
    }
}
