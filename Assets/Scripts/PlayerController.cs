using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// current and max health send as parameters
    /// </summary>
    public static event System.Action<float,float> EventTakeDamage;
    private float maxHealth = 100f;
    private float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        EventTakeDamage?.Invoke(currentHealth,maxHealth);
    }
}
