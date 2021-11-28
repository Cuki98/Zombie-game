using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public HealthComponent healthComponent;

    private Image fill;

    private void Awake()
    {
        healthComponent.OnTakeDamage += OnTakeDamage;
        fill = transform.Find("Background/Fill").GetComponent<Image>();


        fill.fillAmount = healthComponent.GetHealthPercentage();
    }

    private void OnTakeDamage(object sender, HealthComponent.DamageTakenArgs e)
    {
        Debug.Log("Called");
        fill.fillAmount = healthComponent.GetHealthPercentage();
        UiController.i.shakeController.AddShake(0.5f, 5, 5);
    }
}
