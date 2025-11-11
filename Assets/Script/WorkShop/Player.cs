using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [Header("Hand setting")]
    public Transform RightHand;
    public Transform LeftHand;
    public List<Item> inventory = new List<Item>();

    Vector3 _inputDirection;

    bool _isAttacking = false;
    bool _isBlocking = false;
    bool _isInteract = false;

    public Sword currentWeapon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        health = maxHealth;
    }

    public void FixedUpdate()
    {
        Move(_inputDirection);
        Turn(_inputDirection);
        Attack(_isAttacking);
        Block(_isBlocking);
        Interact(_isInteract);
    }
    public void Update()
    {
        HandLeftInput();
        HandRightInput();
    }
    public void AddItem(Item item)
    {
        inventory.Add(item);
    }

    // setting holding in left hand
    private void HandLeftInput()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        _inputDirection = new Vector3(x, 0, y);
        _isAttacking = Input.GetMouseButtonDown(0);
        _isInteract = Input.GetKeyDown(KeyCode.E);

        //add input to Interact
        /*if (Input.GetKeyDown(KeyCode.E))
        {
            IInteractable i = InFront as IInteractable;
            if (i != null)
            {
                i.Interact(this);
            }
        }*/
    }

    // setting holding in right hand
    private void HandRightInput()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        _inputDirection = new Vector3(x, 0, y);
        _isBlocking = Input.GetMouseButtonDown(1);
    }

    public void Attack(bool isAttacking)
    {
        if (isAttacking)
        {
            animator.SetTrigger("Attack");
            //edit to Idestoryable, so, not only enemy that player can destroy
            //Enemy e = InFront as Enemy;
            var e = InFront as Idestroyable;
            if (e != null)
            {
                e.TakeDamage(Damage);
                Debug.Log($"{gameObject.name} attacks for {Damage} damage.");
            }
            _isAttacking = false;
        }
    }

    public void Block(bool isBlocking)
    {
        if (isBlocking)
        {
            animator.SetTrigger("Block");
            Debug.Log($"{gameObject.name} blocks damage.");
        }
    }

    private void Interact(bool isInteracting)
    {
        if (isInteracting)
        {
            IInteractable i = InFront as IInteractable;
            if (i != null)
            {
                i.Interact(this);
            }
            _isInteract = false;

        }
    }

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        GameManager.instance.UpdateHealthText(health);
    }

    public override void Heal(int amount)
    {
        base.Heal(amount);
        GameManager.instance.UpdateHealthText(health);
    }
    ///////////////add method Interact///////////////
}
