using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Mimic : Enemy, IInteractable, IDestroyable
{
    public TMP_Text interactionTextUI;
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
        /*if (currentState == State.run)
        {
            if (agent.remainingDistance <= agent.stoppingDistance) //done with path
            {
                Vector3 point;
                if (RandomPoint(centerPoint.position, range, out point)) //pass in our centre point and radius of area
                {
                    Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                    agent.SetDestination(point);
                }
            }
        }*/

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
        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 20f, NavMesh.AllAreas))
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}
