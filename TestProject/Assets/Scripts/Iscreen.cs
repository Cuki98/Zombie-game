using UnityEngine;
using UnityEngine.Events;

public interface Iscreen 
{

    public void OnScreenActivate();


    public void OnScreenDeactivate();

    public bool HasAnimation();
}
