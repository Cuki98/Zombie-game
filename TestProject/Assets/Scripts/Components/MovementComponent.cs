using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class MovementComponent : MonoBehaviour , IAlive
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float sprintMultiplier;

    private PlayerInput playerInput;

    private float xInput, zInput;
    private Vector2 inputs;

    //Components
    private Rigidbody rig;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void GatherInputs()
    {
        inputs = playerInput.actions["Move"].ReadValue<Vector2>();;
    }

    private void Move()
    {
        GatherInputs();
        Vector3 movementForce = new Vector3();
        rig.velocity = new Vector3(0, rig.velocity.y, 0);

        movementForce = new Vector3(inputs.x, 0, inputs.y) * walkSpeed * Time.deltaTime;
        rig.AddForce(movementForce, ForceMode.Impulse);
    }

    public void Disable()
    {
        enabled = false;
    }
}

public enum MovementType
{
    idle, walking, running
}