using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tools 
{
    public static bool GetValidMouseLocation(this Camera camera , LayerMask mask , out Vector3 mousePosition)
    {
        //Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = camera.ScreenPointToRay(Input.mousePosition);
        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;
        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, mask, 10000))
        {
            mousePosition = floorHit.point;
            return true;
        }
        else
        {
            mousePosition = Vector3.zero;
            return false;
        }
    }
}
