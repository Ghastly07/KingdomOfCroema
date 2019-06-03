using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField]
    private float damage;
    private SkillController skillController;

    private bool shouldTakeDamage = false;

    private void Start()
    {
        skillController = FindObjectOfType<SkillController>();
        skillController.EventDanceSkillStart += ActivateSword;
        skillController.EventDanceSkillEnds += DeactivateSword;
    }

    private void OnDestroy()
    {
        skillController.EventDanceSkillStart -= ActivateSword;
        skillController.EventDanceSkillEnds -= DeactivateSword;
    }

    private void ActivateSword()
    {
        shouldTakeDamage = true;
    }

    private void DeactivateSword()
    {
        shouldTakeDamage = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Data.EnemyTag))
        {
            other.GetComponent<Enemy>().GetDamage(damage);
        }
    }
}
