using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BullBossController : Enemy
{
    private Animator anim;
    private AIBehaviour aiBehaviour;
    private NavMeshAgent navMeshAgent;
    private new void Start()
    {
        anim = GetComponent<Animator>();
        aiBehaviour = GetComponent<AIBehaviour>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(navMeshAgent.remainingDistance < 3)
        {
            AttackTrigger();
        }
        else
        {
            DefyTrigger();
        }
    }

    private void AttackTrigger()
    {
        anim.SetTrigger("attack_01");
    }

    private void DefyTrigger()
    {
        anim.SetTrigger("defy");
    }
    
    private void DieTrigger()
    {
        anim.SetTrigger("die");
    }


    public override void GetDamage(float amount)
    {
        Debug.Log("Enemy " + gameObject.name + " get " + amount + " of damage");
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            DieTrigger();
        }
    }
}
