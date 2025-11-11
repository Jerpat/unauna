using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    protected enum State { idle, chase, attack, death }

    private NavMeshAgent agent;
    public Transform target;

    [SerializeField] //show in inspector even it is private
    private float TimeToAttack = 1f;
    protected State currentState = State.idle;

    [SerializeField]
    protected float timer = 0f;

    private void Update()
    {
        agent = GetComponent<NavMeshAgent>();

        if (player == null)
        {
            animator.SetBool("Attack", false);
            return;
        }

        Turn(player.transform.position - transform.position);
        timer -= Time.deltaTime;

        if (GetDistancePlayer() < 1.5)
        {
            Attack(player);
        }
        else
        {
            animator.SetBool("Attack", false);
        }
    }

    protected override void Turn(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = lookRotation;
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
}
