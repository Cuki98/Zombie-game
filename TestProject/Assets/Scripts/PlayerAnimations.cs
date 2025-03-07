using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimations : MonoBehaviour
{
    public Animator playerAnimator;
    private InputManager inputManager;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
    }
    private void Update() 
    {
        playerAnimator.SetFloat("Direction", inputManager.GatherMovementInputs().x);
        playerAnimator.SetFloat("Speed", inputManager.GatherMovementInputs().y);

     //  if(transform.forward.x > 0)

        if(Input.GetMouseButtonDown(1))
        Debug.Log(transform.forward);

    }
}
