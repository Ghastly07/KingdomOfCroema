using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    [SerializeField]
    private GameObject currentWeapon;
    [SerializeField]
    private Transform attackPosition;
    [SerializeField]
    private float attackRange;
    [SerializeField]
    private LayerMask enemiesLayer;

    private Animator currentWeaponAnimator;

    private bool canDoCombo = false;
    private string currentTrigger = Data.Debug_SwordAttackAnim1;

    private void Start()
    {
        currentWeaponAnimator = currentWeapon.GetComponent<Animator>();
    }

    public void ComboStarted(int attackNumber)
    {
        if (attackNumber == 1)
            currentTrigger = Data.Debug_SwordAttackAnim2;
        else if (attackNumber == 2)
            currentTrigger = Data.Debug_SwordAttackAnim3;
        else if (attackNumber == 3)
            currentTrigger = Data.Debug_SwordAttackAnim1;
        canDoCombo = true;
    }

    public void ComboStopped()
    {
        currentTrigger = Data.Debug_SwordAttackAnim1;
        canDoCombo = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            currentWeaponAnimator.SetTrigger(currentTrigger);
            TryHurtSomeone();
        }
    }

    private void TryHurtSomeone()
    {
        Collider[] enemies = Physics.OverlapSphere(attackPosition.position, attackRange, enemiesLayer);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Enemy>().GetDamage(3); // TODO: Get damage amount from weapon

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }

}
