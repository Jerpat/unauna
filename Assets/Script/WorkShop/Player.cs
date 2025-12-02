using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    [SerializeField]
    private float runSpeed;

    [Header("Camera setting")]
    public Transform camera;

    [Header("Hand setting")]
    public Transform RightHand;
    public Transform LeftHand;
    public Sword currentWeapon;
    public List<Item> inventory = new List<Item>();

    [Header("Starting Items")]
    public Potion potionPrefab;
    public int startingPotionCount = 3;

   [Header("UI")]
    public TMP_Text potionCountText;

    Vector3 _inputDirection;
    
    float mouseSensitivity = 2f;
    float minLookX = -2f;
    float maxLookX = 13f;
    private float currentLookX = 0f;
    private Rigidbody mRig;

    private string currentGround = "Default";

    bool _isRunning = false;
    bool _isAttacking = false;
    bool _isBlocking = false;
    bool _isInteracting = false;
    bool _isHealing = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mRig = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        health = maxHealth;
        UpdatePotionUI();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void FixedUpdate()
    {
        Move(_inputDirection);
        Turn(_inputDirection);
        Attack(_isAttacking);
        Block(_isBlocking);
        Interact(_isInteracting);
    }
    public void Update()
    {
        HandleInput();
        if (_isHealing)
        {
            UsePotion();
            _isHealing = false;
        }
    }
    public void AddItem(Item item)
    {
        inventory.Add(item);
    }

    // setting handle
    private void HandleInput()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;


        if (mouseX != 0 || mouseY != 0)
        {
            MouseLook(mouseX, mouseY);
        }
        else
        {
            mRig.angularVelocity = Vector3.zero;
        }

        _inputDirection = new Vector3(h, 0, v);
        _isRunning = Input.GetKey(KeyCode.LeftShift);
        _isAttacking = Input.GetMouseButtonDown(0);
        _isBlocking = Input.GetMouseButton(1);
        _isInteracting = Input.GetKeyDown(KeyCode.E);
        _isHealing = Input.GetKeyDown(KeyCode.Q);


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

    public void Attack(bool isAttacking)
    {
        if (!isAttacking) return;

        /*if (isAttacking)
        {
            animator.SetTrigger("Attack");
            //edit to Idestoryable, so, not only enemy that player can destroy
            //Enemy e = InFront as Enemy;
            var e = InFront as IDestroyable;
            if (e != null)
            {
                e.TakeDamage(Damage);
                Debug.Log($"{gameObject.name} attacks for {Damage} damage.");
            }
            _isAttacking = false;*/
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animator.Play("Attack", 0, 0f);
        }
        else
        {
            animator.SetTrigger("Attack");
        }

        var e = InFront as IDestroyable;
        if (e != null)
        {
            e.TakeDamage(Damage);
            Debug.Log($"{gameObject.name} attacks for {Damage} damage.");
            
        }
        _isAttacking = false;

        /*animator.SetTrigger("Attack");

        Ray ray = new Ray(camera.position, camera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            var e = hit.collider.GetComponent<IDestroyable>();
            if (e != null)
            {
                e.TakeDamage(Damage);
                Debug.Log($"{gameObject.name} attacks {e} for {Damage} damage.");
            }
        }*/
    
    }

    private void Block(bool isBlocking)
    {
        if (isBlocking)
        {
            animator.SetBool("Block",isBlocking);
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
            _isInteracting = false;
        }
    }

    public override void TakeDamage(int amount)
    {
        if (_isBlocking)
        {
            base.TakeDamage(amount - 10);
        }
        else
        {
            base.TakeDamage(amount);
        }
        GameManager.instance.UpdateHealthText(health);
        GameManager.instance.UpdateHealthBar(health, maxHealth);
    }

    public override void Heal(int amount)
    {
        base.Heal(amount);
        GameManager.instance.UpdateHealthText(health);
        GameManager.instance.UpdateHealthBar(health, maxHealth);
        SoundManager.instance.PlaySFX(SoundManager.instance.healSFX);
    }
    private void UsePotion()
    {
        Potion potion = inventory.Find(item => item is Potion) as Potion;

        if (potion != null)
        {
            Heal(potion.healAmount); 
            inventory.Remove(potion); 
            UpdatePotionUI();     
            Debug.Log($"Used potion.");
        }
    }

    public void UpdatePotionUI()
    {
        int potionCount = inventory.FindAll(item => item is Potion).Count;
        Debug.Log($"Collect Potions, Potions: {potionCount}");
        if (potionCountText != null)
        {
            potionCountText.text = $"{potionCount}";
        }
    }

    protected override void Turn(Vector3 direction)
    {
        /*Vector3 inputDir = new Vector3(direction.x, 0f, direction.z);
        if (inputDir.sqrMagnitude < 0.01f) return;

        if (direction.z < 0f) return;

        Vector3 moveDirection = (transform.forward * direction.z) + (transform.right * direction.x);
        moveDirection.y = 0f;

        if (moveDirection.sqrMagnitude < 0.001f) return;

        Quaternion targetRot = Quaternion.LookRotation(moveDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 10f * Time.deltaTime);*/
    }

    protected override void Move(Vector3 direction)
    {
        Vector3 moveDirection = (transform.forward * direction.z) + (transform.right * direction.x);
        moveDirection.Normalize();

        if (_isRunning)
        {
            rb.linearVelocity = new Vector3(moveDirection.x * runSpeed, rb.linearVelocity.y, moveDirection.z * runSpeed);
            animator.SetFloat("Speed", new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z).magnitude);
        }
        else
        {
            rb.linearVelocity = new Vector3(moveDirection.x * walkSpeed, rb.linearVelocity.y, moveDirection.z * walkSpeed);
            animator.SetFloat("Speed", new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z).magnitude);
        }

        if (direction.magnitude > 0.1f)
        {
            CheckGroundType();
            SoundManager.instance.PlayFootstep(currentGround, _isRunning);
        }
    }
    void CheckGroundType()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 2f))
        {
            currentGround = hit.collider.tag;
        }
    }

    private void MouseLook(float mouseX, float mouseY)
    {
        //Look Y
        float horizontalSpeed = 50f;
        transform.Rotate(0f, mouseX * mouseSensitivity * Time.deltaTime * horizontalSpeed, 0f);

        //Look X
        float verticalSpeed = 50f;
        currentLookX -= mouseY * mouseSensitivity * Time.deltaTime * verticalSpeed;
        currentLookX = Mathf.Clamp(currentLookX, minLookX, maxLookX);
        camera.localRotation = Quaternion.Euler(currentLookX, 0f, 0f);
    }
}
