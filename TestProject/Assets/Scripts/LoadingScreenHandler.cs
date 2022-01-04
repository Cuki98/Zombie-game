using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreenHandler : MonoBehaviour
{
    public Camera cam;
    public List<GameObject> Zones = new List<GameObject>();
    public List<Transform> cameraZones = new List<Transform>();
    private int cameraZoneIndex= -1;
    private GameObject activeZone;

    private void Awake()
    {
     //   SetNewRandomZone();
    }

    private void SetNewRandomZone()
    {
        if (activeZone) activeZone.SetActive(false);

        activeZone = Zones[Random.Range(0 , Zones.Count)];
        activeZone.SetActive(true);


        GameObject zoneHolder = activeZone.transform.Find("CameraZones").gameObject;

        List<Transform> newCameraZones = new List<Transform>();

        for (int i = 0; i < zoneHolder.transform.childCount; i++)
        {
            newCameraZones.Add(zoneHolder.transform.GetChild(i));
        }
        cameraZones = new List<Transform>(newCameraZones);
        cameraZoneIndex = -1;

        cam.transform.position = cameraZones[0].position;
        SetNewCameraZone();
    }

    private void SetNewCameraZone()
    {
        if (cameraZoneIndex >= cameraZones.Count - 1)
        {
            SetNewRandomZone();
            return;
        }

        cameraZoneIndex++;
        Roam();
    }
    public void Roam()
    {
        LeanTween.move(cam.gameObject , cameraZones[cameraZoneIndex].position, 10f).setOnComplete(SetNewCameraZone).setEaseLinear();
        LeanTween.rotate(cam.gameObject , cameraZones[cameraZoneIndex].rotation.eulerAngles , 10f).setEaseLinear();
    }
}
