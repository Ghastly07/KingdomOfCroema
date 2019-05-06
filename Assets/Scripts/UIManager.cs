using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Image healthImage;

    private void Start()
    {
        PlayerController.EventTakeDamage += UpdateHealthSlider;
        PlayerController.EventHeal += UpdateHealthSlider;
    }

    private void OnDestroy()
    {
        PlayerController.EventTakeDamage -= UpdateHealthSlider;
        PlayerController.EventHeal -= UpdateHealthSlider;
    }

    private void UpdateHealthSlider(float currentHealthValue, float maxHealth)
    {
        healthImage.fillAmount = Mathf.Clamp01(currentHealthValue/maxHealth);
    }



}
