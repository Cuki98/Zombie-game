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
        playerAnimator.SetFloat("Direction", inputManager.GetStickValue().x);
        playerAnimator.SetFloat("Speed", transform.forward.z);
        Debug.Log(transform.forward.z);
    }
}
