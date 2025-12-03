using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Mimic : Enemy, IInteractable, IDestroyable
{
    public TMP_Text interactionTextUI;

    public GameObject DropItem;

    public bool canTalk = true;
    public bool isInteractable { get => canTalk; set => canTalk = value; }

    public float range; //radius of sphere
    public Transform centerPoint; //centre of the area the agent wants to move around in

    private bool isPaused = false;
    private float pauseTime = 0f;

    public void Interact(Player player)
    {
        if (currentState == State.idle)
        {
            interactionTextUI.gameObject.SetActive(false);
            currentState = State.run;
        }
    }

    protected override void Update()
    {

        if (currentState != State.run) return;

        if (isPaused)
        {
            pauseTime -= Time.deltaTime;
            if (pauseTime <= 0f)
            {
                isPaused = false;
                SetNewDestination();
            }
            return;
        }

        if (agent.remainingDistance <= agent.stoppingDistance + 0.1f)
        {
            StartPause();
        }
    }
    private void StartPause()
    {
        isPaused = true;
        pauseTime = Random.Range(1f, 1.7f);

        agent.ResetPath();
        animator.SetBool("Run", false);
    }

    private void SetNewDestination()
    {
        Vector3 point;
        if (RandomPoint(centerPoint.position, range, out point))
        {
            agent.SetDestination(point);
            animator.SetBool("Run", true);
        }
    }

    private bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 20f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    public override void TakeDamage(int amount)
    {        
        health -= amount;

        if (health <= 0)
        {
            GameObject g = Instantiate(DropItem, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
