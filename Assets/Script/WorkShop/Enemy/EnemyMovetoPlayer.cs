using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovetoPlayer : Enemy
{

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
            Vector3 direction = (player.transform.position - transform.position).normalized;
            Move(direction);
        }
    }
}
