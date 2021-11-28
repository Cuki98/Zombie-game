using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[System.Serializable]public class GasAction
{
    public Action callback;
    public GasActionTag actionTag;
    public GasActionTag[] invalidTags;

    private ActionManager manager;
    public event EventHandler OnActionCancelled;

    public GasAction(ActionManager manager,Action callback, GasActionTag actionTag, GasActionTag[] invalidTags = null)
    {
        this.callback = callback;
        this.actionTag = actionTag;
        this.invalidTags = invalidTags;
        this.manager = manager;
    }

    public GasAction(ActionManager manager, Action callback)
    {
        this.callback = callback;
        this.manager = manager;
    }

    public void OverrideAction(Action action)
    {
        this.callback = action;
    }
    public bool HasInvalidTags()
    {
        return invalidTags != null && invalidTags.Length > 0;
    }
    public void ExecuteAction()
    {
        if (manager)
        {
          bool actionValidForInvoke = manager.AnalizeAction(this);

            if (actionValidForInvoke)
            {
                manager.AddActionTag(actionTag);
                callback?.Invoke();
            }
            else
                CancelAction();
        }
    }
    public void CancelAction()
    {
        Debug.Log("ActionCancelled");
        OnActionCancelled?.Invoke(this , EventArgs.Empty);
    }
}

public enum GasActionTag
{
    shooting , moving , walking , running , switchWeapons, 
}
