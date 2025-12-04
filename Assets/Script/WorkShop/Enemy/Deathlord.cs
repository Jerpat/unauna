using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using TMPro;

public class Deathlord : Enemy, IInteractable, IDestroyable
{
    public TMP_Text interactionTextUI;
    public TMP_Text WordTextUI;

    public GameObject DropItem;
    protected bool isProvoked = false;
    public bool canTalk = true;

    public bool isInteractable { get => canTalk; set => canTalk = value; }

    public void Interact(Player _player)
    {
        WordTextUI.gameObject.SetActive(true);
        Invoke("CloseWord", 3);
    }

    protected override void Update()
    {
        timer -= Time.deltaTime;
        if(player != null)
        {
            if (GetDistancePlayer() <= seeRange)
            {
                Turn(player.transform.position - transform.position);
            }
        }

        if (GetDistancePlayer() >= 2f || !canTalk)
        {
            interactionTextUI.gameObject.SetActive(false);
        }
        else
        {
            interactionTextUI.gameObject.SetActive(true);
        }


        if (!isProvoked || player == null)
        {
            idleState();
            return;
        }

        if (GetDistancePlayer() <= atkRange)
        {
            Attack(player);
        }
        else
        {
            idleState();
        }
    }

    public override void TakeDamage(int amount)
    {
        isProvoked = true;
        Debug.Log($"{Name} was provoked and start counter attacking");

        health -= amount;

        if (health <= 0)
        {
            GameObject g = Instantiate(DropItem, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
