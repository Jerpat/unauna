using UnityEngine;

public class Enemy : Character
{
    protected enum State { idel, cheses, attack, death }

    [SerializeField]
    private float TimeToAttack = 1f;
    protected State currentState = State.idel;
    protected float timer = 0f;
    private void Update()
    {
        if (player == null)
        {
            animator.SetBool("Attack", false);
            return;
        }

        Turn(player.transform.position - transform.position);
        timer -= Time.deltaTime;

        if (GetDistanPlayer() < 1.5)
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
    protected virtual void Attack(Player _player) {
        if (timer <= 0)
        {
            _player.TakeDamage(Damage);
            animator.SetBool("Attack", true);
            Debug.Log($"{Name} attacks {_player.Name} for {Damage} damage.");
            timer = TimeToAttack;
        }
        
    }
}
