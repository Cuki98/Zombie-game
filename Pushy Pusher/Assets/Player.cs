using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    

    [SerializeField] private float walkSpeed;
    [SerializeField] private float sprintMultiplier;

 

    private float xInput, zInput;


    //Components
    private Rigidbody rig;
    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        LookRotation();
        Move();
    }

    public void LookRotation()
    {
        //Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;
        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, 10000))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;
            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;
            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);
            // Set the player's rotation to this new rotation.
            transform.rotation = newRotatation;
        }
    }
    private void GatherInputs()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        zInput = Input.GetAxisRaw("Vertical");
    }

    private void Move()
    {
        GatherInputs();
        Vector3 movementForce = new Vector3();
        rig.velocity = new Vector3(0, rig.velocity.y, 0);

        movementForce = new Vector3(xInput, 0, zInput) * walkSpeed * Time.deltaTime;
        rig.AddForce(movementForce, ForceMode.Impulse);
    }
}
