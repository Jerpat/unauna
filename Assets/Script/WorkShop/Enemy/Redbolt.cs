using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class Redbolt : Enemy, IInteractable, ITalkable
{
    //Interface SetUp
    protected bool isChasing = false;
    private bool canTalk = true;
    private bool canInteract = true;

    //Interact Text
    public TMP_Text interactionTextUI;

    //Talking Conversations Text 
    public GameObject TalkingPanel;
    public TMP_Text TalkingText;
    public TMP_Text TalkingNameText;
    public string[] TalkingLines;
    private int index = 0;
    public bool isInteractable { get => canTalk; set => canTalk = value; }

    public bool isTalkable { get => canTalk; set => canTalk = value; }

    public override void SetUP()
    {
        //Interact Text Setting
        interactionTextUI = GetComponentInChildren<TMP_Text>();

        //UI Setting
        TalkingPanel.gameObject.SetActive(false);
    }

    public void Interact(Player _player)
    {
        isChasing = true;
        Debug.Log($"{Name} start chasing {_player.Name}");
    }

    public void Talk(Player player)
    {
        //UI Setting
        TalkingPanel.gameObject.SetActive(true);
        TalkingNameText.text = "Redbolt";

        //Talking All Lines before Give Quest
        if (index < TalkingLines.Length)
        {
            TalkingText.text = TalkingLines[index];
            index++;
            return;
        }
        else
        {
            SceneManager.LoadScene(04);
        }
    }

    protected override void Update()
    {
        //Interact Text Update
        if (GetDistancePlayer() >= 2f || !canInteract)
        {
            interactionTextUI.gameObject.SetActive(false);
        }
        else
        {
            interactionTextUI.gameObject.SetActive(true);
        }

        //base.Update();
        timer -= Time.deltaTime;

        if (!isChasing || player == null)
        {
            idleState();
            return;
            
        }
        /*
        else if (isChasing)
        {
            Chase(player);
        }

        Attack(player);*/

        Character closestT = FindClosestTarget<Buzzvenom>();
        if (closestT != null)
        {
            float distance = Vector3.Distance(transform.position, closestT.transform.position);
            if (distance > atkRange)
            {
                agent.SetDestination(closestT.transform.position);
                animator.SetBool("Attack", false);
            }
            else
            {
                agent.ResetPath();
                Attack(null);
            }
        }
        else
        {
            Chase(player);
        }
    }

    /*public void Chase(Player _player)
    {
        //Vector3 destination = _player.transform.position;
        if (GetDistancePlayer() < seeRange && GetDistancePlayer() > atkRange)
        {
            agent.SetDestination(_player.transform.position);
        }
    }*/

    protected Character FindClosestTarget<T>() where T : Character
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, seeRange);
        Character closest = null;
        float minDist = Mathf.Infinity;

        foreach (Collider hit in hits)
        {
            if (hit.gameObject == this.gameObject) continue;
            
                T t = hit.GetComponent<T>();
                if (t != null)
                {
                    float dist = Vector3.Distance(transform.position, t.transform.position);
                    if (dist < minDist)
                    {
                        minDist = dist;
                        closest = t;
                    }
                }
        }
        return closest;
    }
    

    protected override void Attack(Player _player)
    {
        if (timer > 0) return;

        /*Collider[] hits = Physics.OverlapSphere(transform.position, seeRange);
        List<Character> ListTarget = new List<Character>();
        foreach (Collider hit in hits)
        {
            if (hit.gameObject != this.gameObject)
            {
                Buzzvenom c = hit.GetComponent<Buzzvenom>();
                if (c != null)
                {
                    ListTarget.Add(c);
                }
            }
        }
        Character _target = null;
        float targetDistance = Mathf.Infinity;

        foreach (Character c in ListTarget)
        {
            float distacne = Vector3.Distance(transform.position, c.transform.position);
            //float Targetdistacne = Vector3.Distance(transform.position, _target.transform.position);
            if (distacne < targetDistance)
            {
                targetDistance = distacne;
                _target = c;
            }
        }*/

        Character _target = FindClosestTarget<Buzzvenom>();

        if (_target == null || timer > 0) return;
        {
            Turn(_target.transform.position - transform.position);
            agent.SetDestination(_target.transform.position);

            _target.TakeDamage(Damage);
            animator.SetTrigger("Attack");
            Debug.Log($"{Name} attacks {_target.Name} for {Damage} damage.");
            timer = TimeToAttack;
        }
    }
}

