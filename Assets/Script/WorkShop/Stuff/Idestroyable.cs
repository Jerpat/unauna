using UnityEngine;

public interface Idestroyable
{
    int health { get; set; }

    int maxHealth { get; set; }

    void TakeDamage(int damageAmount);

    event System.Action<Idestroyable> OnDestroy;

}
