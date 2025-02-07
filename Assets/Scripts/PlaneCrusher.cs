using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaneCrusher : MonoBehaviour
{
    public GameObject currentSelectedObject;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other != null)
        {
            //Debug.Log("Trigger Stay with: " + other.gameObject.name);
            if (Input.GetMouseButtonDown(1) || OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.1f || OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.1f)
            {
                currentSelectedObject = other.gameObject;
                gameObject.SetActive(false);
            }
        }
    }
}
