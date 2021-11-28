using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;




[System.Serializable]
public class GAtribute
{
    public AttributeName attributeClass;
    [SerializeField] private float value = 0;
    public ClampingValues clampValues = new ClampingValues();

    public float Value
    {
        get { return value; }
        set
        {

            float previousValue = this.value;
            this.value = Mathf.Clamp(value, clampValues.minimum, clampValues.maximum);

            if (this.value != previousValue)
                OnAttributeChange?.Invoke(this, new AttributeCarrier { v = value });

            if (this.value < previousValue)
            {
                OnAttributeDecrease?.Invoke(this, new AttributeCarrier { v = value });
            }
            else if (this.value > previousValue)
            {
                OnAttributeIncrease?.Invoke(this, new AttributeCarrier { v = value });
            }
        }
    }

    public event EventHandler<AttributeCarrier> OnAttributeChange;
    public event EventHandler<AttributeCarrier> OnAttributeIncrease;
    public event EventHandler<AttributeCarrier> OnAttributeDecrease;


    public static GAtribute SetUpAttribute(GameObject obj,  AttributeName attributeName)
    {
        AttributeHolder attributeH;
        attributeH = obj.GetComponent<AttributeHolder>();
        if (attributeH) return attributeH.GetAttribute(attributeName);
        else return null;
    }


    public class AttributeCarrier : EventArgs
    {
        public float v;
    }
}

[System.Serializable]
public class ClampingValues
{
    public float minimum;
    public float maximum;
}
