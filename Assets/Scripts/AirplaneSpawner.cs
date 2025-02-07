using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private GameObject rightController;

    public bool plane_spawned = false;
    public GameObject planeController;
    public GameObject plane;

    private void Start()
    {
        plane.SetActive(false);
    }

    void Update()
    {
        // OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.1f
        if (Input.GetMouseButtonDown(0) || OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.1f)
        {
            SpawnAirplane();
        }
    }
    private void SpawnAirplane()
    {
        // Plane can spawn somewhere AND (plane not exist OR plane hidden)
        if (spawnPoint != null && (!plane_spawned || !plane.activeSelf))
        {
            planeController.transform.position = spawnPoint.position;// + new Vector3(0.0f, 1f, 0.0f); //spawnPoint.position;
            planeController.transform.rotation = Quaternion.LookRotation(rightController.transform.forward);
            //plane.transform.localScale = Vector3.one * 0.025f;
            plane.SetActive(true);
            plane_spawned=true;
        }
        else
        {
            Debug.LogWarning((spawnPoint != null) + "; " + plane_spawned + "; " + plane.activeSelf + "; Airplane prefab or spawn point is not assigned!");
        }
    }
}
