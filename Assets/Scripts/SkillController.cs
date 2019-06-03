using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public event System.Action EventDanceSkillStart;
    public event System.Action EventDanceSkillEnds;
    public event System.Action<float> EventHeal;

    public GameObject effect;
    private float healValue = 20;
    private float healCooldown = 5;
    private float healTimer;

    [SerializeField]
    private LayerMask enemiesLayer;

    [Header("Dance around skill")]
    [SerializeField]
    private float rotateAroundDuration;

    private bool isDancing = false;

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

        if(Input.GetKeyDown(KeyCode.F2) && !isDancing)
        {
            StartCoroutine(DanceSkill(rotateAroundDuration));
        }
    }

    private void SpawnEffect()
    {
        Instantiate(effect, transform.position, Quaternion.identity, transform);
    }

    IEnumerator DanceSkill(float duration)
    {
        EventDanceSkillStart?.Invoke();
        isDancing = true;
        float startRotation = transform.eulerAngles.y;
        float endRotation = startRotation + 720.0f;
        float t = 0.0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float yRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 720.0f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
            yield return null;
        }
        isDancing = false;
        EventDanceSkillEnds?.Invoke();
    }

}
