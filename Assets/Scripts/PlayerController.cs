using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkillController))]
public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// current and max health send as parameters
    /// </summary>
    public static event System.Action<float,float> EventTakeDamage;
    public static event System.Action<float, float> EventHeal;
    private float maxHealth = 100f;
    private float currentHealth;
    private SkillController skillController;

    private void Start()
    {
        currentHealth = maxHealth;
        skillController = GetComponent<SkillController>();
        skillController.EventHeal += Heal;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        EventTakeDamage?.Invoke(currentHealth,maxHealth);
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        EventHeal?.Invoke(currentHealth, maxHealth);
    }

    private void OnDestroy()
    {
        skillController.EventHeal -= Heal;
    }
}
