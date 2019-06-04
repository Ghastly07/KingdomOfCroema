using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float maxHealth = 10;
    protected float currentHealth;

    protected void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void GetDamage(float amount)
    {
        Debug.Log("Enemy " + gameObject.name + " get " + amount + " of damage");
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            TutorialManager.Instance.EnemiesDefeated();
            Destroy(gameObject);
        }
    }

}
