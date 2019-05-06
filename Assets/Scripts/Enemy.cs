using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 10;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void GetDamage(float amount)
    {
        Debug.Log("Enemy " + gameObject.name + " get " + amount + " of damage");
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Destroy(gameObject);
        }
    }

}
