using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //Checks
    private bool isBuildingMode;
    private bool buildIsValid { get { return isBuildingMode && blueprintPrefab ; } }

    public Blueprint prefab;
    private Blueprint blueprintPrefab;
    public LayerMask buildingMask;

    private Vector3 mousePos;

    private void Update()
    {
     //   CollectInputs();

        //if (Tools.GetValidMouseLocation(Camera.main, buildingMask, out mousePos) && isBuildingMode)
        //{
        //    blueprintPrefab.transform.position = mousePos;
        //}


    }
    private void CollectInputs()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnBlueprint();
        }
        if (Input.GetMouseButtonDown(1))
        {
            CancelBuild();
        }
        if (Input.GetMouseButtonDown(0))
        {
            PlaceBuilding();
        }
    }
    public void SpawnBlueprint()
    {
        if (blueprintPrefab == null)
        {
            blueprintPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            isBuildingMode = true;
        }
    }
    public void PlaceBuilding()
    {
        if (buildIsValid)
        {
            Instantiate(prefab.prefab , mousePos , Quaternion.identity);
        }
    }
    public void CancelBuild()
    {
        Destroy(blueprintPrefab);
        isBuildingMode = false;
    }
    public void Snap()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10);
        Transform ClosestSnapPoint = null;
        float closestDistance = Mathf.Infinity;

        for (int i = 0; i < hitColliders.Length; i++)
        {
           Snap snapComp =  hitColliders[i].gameObject.GetComponent<Snap>();

            if (snapComp)
            {
               
                for (int x = 0; x < snapComp.snapPoints.Length; x++)
                {
                    Transform currentSnapPoint = snapComp.snapPoints[i];
                    float currentDistance;

                    if (ClosestSnapPoint == null) ClosestSnapPoint = snapComp.snapPoints[i];

                    currentDistance = Vector3.Distance(transform.position, currentSnapPoint.position);

                    if (currentDistance < closestDistance)
                    {
                        closestDistance = currentDistance;
                        ClosestSnapPoint = currentSnapPoint;
                    }
                }
            }
        }

        if (closestDistance <= 5f)
        {
            transform.position = ClosestSnapPoint.position;
        }
    }

}
