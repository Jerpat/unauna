using UnityEngine;

public interface IDestroyable
{
    int health { get; set; }

    int maxHealth { get; set; }

    void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
    }

    event System.Action<IDestroyable> OnDestroy;

}
