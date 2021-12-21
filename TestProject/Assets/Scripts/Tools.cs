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
    public static Vector3 CalculateDirection(this Vector3 startPosition, Vector3 target)
    {
        return new Vector3() + (target - startPosition).normalized;
    }
    public static Color GetColorByHex(string hexValue)
    {
        Color newCol;
        if (ColorUtility.TryParseHtmlString(hexValue, out newCol))
        {
            return newCol;
        }
        else
        {
            Debug.LogError("Color Hex was invalid");
            return Color.black;
        }
    }

    public static void SetLayerRecursively(GameObject go, int layerNumber)
    {
        foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNumber;
        }
    }

    public static float GetNumberBetween(float  a , float b)
    {
       int random = Random.Range(0 , 1);

        if (random == 0) return a;
        else return b;
       
    }

    public static bool IsInLayerMask(GameObject obj, LayerMask layerMask)
    {
        return ((layerMask.value & (1 << obj.layer)) > 0);
    }
}
