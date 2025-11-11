using TMPro;
using UnityEngine;

public class EnemyTalktoFight : Enemy, IInteractable
{
    public bool canTalk = true;
    
    public bool isInteractable { get => canTalk; set => canTalk = value; } 

    public TMP_Text interactionTextUI;
    public TMP_Text WordTextUI;

    protected override void Update()
    {
        if (player == null)
        {
            animator.SetBool("Attack", false);
            return;
        }
        Turn(player.transform.position - transform.position);

        if (currentState == State.idle)
        {
            IdleState();
        }
        else if (currentState == State.attack) {
            AttackState();
        }
        
    }

    private void IdleState()
    {
        if (GetDistancePlayer() >= 2f || !canTalk)
        {
            interactionTextUI.gameObject.SetActive(false);
        }
        else
        {
            interactionTextUI.gameObject.SetActive(true);
        }
    }
    private void AttackState()
    {
        if (player == null)
        {
            animator.SetBool("Attack", false);
            return;
        }
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

    public void Interact(Player player)
    {
        Debug.Log("Interact");
        if (currentState == State.idle) {
            interactionTextUI.gameObject.SetActive(false);
            currentState = State.attack;
        }
        WordTextUI.gameObject.SetActive(true);

        Invoke("CloseWord",3);
    }
    void CloseWord() {
        WordTextUI.gameObject.SetActive(false);
    }
}
