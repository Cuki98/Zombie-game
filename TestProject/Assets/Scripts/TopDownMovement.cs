using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{

    public float speed = 6f;

    private InputManager inputManager;
    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        inputManager = GetComponent<InputManager>();
    }

    private void Update()
    {
        Vector2 inputs = inputManager.GatherMovementInputs();
        Vector3 direction = new Vector3(inputs.x , 0 , inputs.y);


        if (direction.magnitude >= .1f)
        {
            controller.Move(direction.normalized  * Time.deltaTime * speed);
        }
    }
}
