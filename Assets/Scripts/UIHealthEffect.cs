using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthEffect : MonoBehaviour
{
    private Image effectImage;

    [SerializeField]
    private float lerpTime = 0.25f;
    [SerializeField]
    private float delay = 0.4f;

    private float currentLerpTime;

    private float currentFillValue;
    private float endFillValue;
    private bool isAnimating = false;

    private void Start()
    {
        effectImage = GetComponent<Image>();
        currentFillValue = effectImage.fillAmount;
        PlayerController.EventTakeDamage += Activate;
    }

    private void OnDestroy()
    {
        PlayerController.EventTakeDamage -= Activate;
    }

    private void Activate(float currentHealthValue,float maxHealth)
    {
        StartCoroutine(ActivateEffect(currentHealthValue/maxHealth));
    }

    private IEnumerator ActivateEffect(float endValue)
    {
        yield return new WaitForSeconds(delay);
        currentLerpTime = 0;
        endFillValue = endValue;
        currentFillValue = effectImage.fillAmount;
        isAnimating = true;
    }

    private void Update()
    {
        if (isAnimating)
        {
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
                isAnimating = false;
            }

            float percentage = currentLerpTime / lerpTime;
            effectImage.fillAmount = Mathf.Lerp(currentFillValue, endFillValue, percentage);
        }
    }


}
