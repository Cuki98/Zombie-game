using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    private List<GasActionTag> activeTags = new List<GasActionTag>();

    public bool AnalizeAction(GasAction action)
    {
        bool tagIsContained = activeTags.Contains(action.actionTag);

        for (int i = 0; i < activeTags.Count; i++)
        {
            for (int x = 0; x < action.invalidTags.Length; x++)
            {
                if (activeTags[i] == action.invalidTags[x])
                {
                    Debug.Log("Aye");
                    return false;
                }
            }
        }

        return true;
    }

    public void AddActionTag(GasActionTag tag)
    {
        if (!activeTags.Contains(tag))
        activeTags.Add(tag);
    }
    public void RemoveActionTag(GasActionTag tag)
    {
        activeTags.Remove(tag);
    }
}
