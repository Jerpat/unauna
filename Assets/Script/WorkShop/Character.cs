using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Character : Identity, Idestroyable
{
    int _health;
    public int health
    {
        get { return _health; }
        set { _health = Mathf.Clamp(value, 0, _maxHealth); }
    }
    
    //------------------------------------------------------

    [SerializeField]
    private int _maxHealth = 100;
    public int maxHealth { get { return _maxHealth; } set { _maxHealth = value; } }

    public int Damage = 10;
    public int Defense = 10;
    public float movementSpeed;

    public GameManager gm;

    protected Animator animator;
    protected Rigidbody rb;
    Quaternion newRotation;

    public event Action<Idestroyable> OnDestroy;

    //------------------------------------------------------

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void SetUP()
    {
        base.SetUP();
        health = _maxHealth;

        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on " + gameObject.name);
        }
    }
    public void TakeDamage(int amount)
    {
        amount = Mathf.Clamp(amount - Defense, 1, amount);
        health -= amount;

        /*if (gm != null)
        {
            gm.UpdateHealth(health);
        }

        Debug.Log($"{gameObject.name} HP : {health}");

        if (health <= 0)
        {
            Destroy(gameObject);
        }*/
    }

    public void Heal(int amount)
    {
        health += amount;
        if (health > _maxHealth)
        {
            health = _maxHealth;
        }
        /*if (gm != null)
        {
            gm.UpdateHealth(health);
        }
        Debug.Log($"{gameObject.name} HP : {health}");*/
    }
    protected virtual void Turn(Vector3 direction)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 15f);

        if (rb.linearVelocity.magnitude < 0.1f || direction == Vector3.zero) return;
        newRotation = Quaternion.LookRotation(direction);
    }
    protected virtual void Move(Vector3 direction)
    {
        rb.linearVelocity = new Vector3(direction.x * movementSpeed, rb.linearVelocity.y, direction.z * movementSpeed);
        animator.SetFloat("Speed", rb.linearVelocity.magnitude);
    }


}
