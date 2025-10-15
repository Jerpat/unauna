using TMPro;
using UnityEngine;

public class EnemyTalktoFight : Enemy, IInteractable
{
    

    public bool canTalk = true;
    
    public bool isInteractable { get => canTalk; set => canTalk = value; } 
    public TMP_Text interactionTextUI;
    public TMP_Text WordTextUI;

    public void Update()
    {
        if (player == null)
        {
            animator.SetBool("Attack", false);
            return;
        }
        Turn(player.transform.position - transform.position);

        if (currentState == State.idel)
        {
            IdelState();
        }
        else if (currentState == State.attack) {
            attakeState();
        }
        
    }

    private void IdelState()
    {
        if (GetDistanPlayer() >= 2f || !canTalk)
        {
            interactionTextUI.gameObject.SetActive(false);
        }
        else
        {
            interactionTextUI.gameObject.SetActive(true);
        }
    }
    private void attakeState()
    {
        if (player == null)
        {
            animator.SetBool("Attack", false);
            return;
        }
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

    public void Interact(Player player)
    {
        Debug.Log("Interact");
        if (currentState == State.idel) {
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
