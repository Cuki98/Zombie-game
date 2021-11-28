using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthComponent : MonoBehaviour
{

    public GAtribute health;
    public event EventHandler OnHealthRunOut;
    public event EventHandler<DamageTakenArgs> OnTakeDamage;



    private void Awake()
    {
        health = GAtribute.SetUpAttribute(gameObject  , AttributeName.health);
        health.OnAttributeDecrease += OnAttributeDecrease;
    }

    private void Update()
    {  
    }
    public void TakeDamage(float damage, DamageType dType)
    {
        health.Value -= damage;
        OnTakeDamage.Invoke(this, new DamageTakenArgs { damage = damage, damageType = dType });
    }
    public void Heal(float heal)
    {
        health.Value += heal;
    }
    public void HealPercentage(float percentage)
    {
        health.Value += (health.Value / 100) * percentage;
        
    }

    public float GetHealthPercentage()
    {
        return (health.Value / 100);
    }
    public void RestoreHealth()
    {
        health.Value = health.clampValues.maximum;
    }
    private void OnAttributeDecrease(object sender, GAtribute.AttributeCarrier e)
    {
        if (e.v <= 0)
        {
            OnHealthRunOut?.Invoke(this, EventArgs.Empty);
        }
    }


    public class DamageTakenArgs : EventArgs
    {
        public float damage;
        public DamageType damageType;
    }
}
