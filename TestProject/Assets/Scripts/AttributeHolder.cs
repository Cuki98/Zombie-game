using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeHolder : MonoBehaviour
{
    public List<GAtribute> attributes = new List<GAtribute>();

    public void AddNewAttribute(GAtribute attribute)
    {
        bool containsattribute = attributes.Find(x => x.attributeClass == attribute.attributeClass) != null;

        if(!containsattribute)
        attributes.Add(attribute);
    }

    public GAtribute GetAttribute(AttributeName name)
    {
        return attributes.Find(x => x.attributeClass == name);
    }
}
