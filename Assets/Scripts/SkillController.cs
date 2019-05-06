using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public event System.Action<float> EventHeal;
    public GameObject effect;
    private float healValue = 20;
    private float healCooldown = 5;
    private float healTimer;

    private void Start()
    {
        healTimer = 0;  // So that you don't have to wait on start
    }

    private void Update()
    {
        healTimer -= Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.F1) && healTimer <= 0)
        {
            EventHeal?.Invoke(healValue);
            SpawnEffect();
            healTimer = healCooldown;
        }
    }

    private void SpawnEffect()
    {
        Instantiate(effect, transform.position, Quaternion.identity, transform);
    }
}
