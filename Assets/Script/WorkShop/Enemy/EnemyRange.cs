using UnityEngine;

public class EnemyRange : Enemy
{
    public float attackRange = 5f; // Range within which the enemy can attack

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            animator.SetBool("Attack", false);
            return;
        }
        Turn(player.transform.position - transform.position);
        timer -= Time.deltaTime;
        if (GetDistanPlayer() < attackRange)
        {
            Attack(player);
        }
        else
        {
            animator.SetBool("Attack", false);
        }
    }
}
