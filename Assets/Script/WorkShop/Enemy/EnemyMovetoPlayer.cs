using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovetoPlayer : Enemy
{
    /*public Transform target;
    public float seeRange = 7f;

    private NavMeshAgent agent;*/

    private void Update()
    {
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
            Vector3 direction = (player.transform.position - transform.position).normalized;
            Move(direction);
        }
    }
    /*private void Update()
    {
        agent = GetComponent<NavMeshAgent>();

        Vector3 destination = Player.transform.position;

        if (GetDistanPlayer() < seeRange)
        {
            agent.SetDestination(destination);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, seeRange);
    }*/
}
