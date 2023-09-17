using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class debugmessage : MonoBehaviour
{
    public Text msg;
    public bool placed = false;

    public ARRaycastManager MyArRaycastNaManager;
    private ARPlaneManager planemanager;

    public GameObject chosenPortal;
    

    public void Start()
    {
        msg.text = "Application Started";
        MyArRaycastNaManager = GameObject.Find("AR Session Origin").GetComponent<ARRaycastManager>();
        planemanager = GameObject.Find("AR Session Origin").GetComponent<ARPlaneManager>();
    }

    public void Update()
    {
        if (Input.touchCount > 0)
        {
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            bool hitrue =
                MyArRaycastNaManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon);

            if (hitrue && placed == false)
            {
                ARRaycastHit hit = hits[0];
                
                ARPlane plane = planemanager.GetPlane(hit.trackableId);
                msg.text = plane.transform.position + " " + plane.transform.rotation + " " + plane.name; 
                Instantiate(chosenPortal, hit.pose.position, plane.transform.rotation);
                planemanager.SetTrackablesActive(false);
                planemanager.enabled = false;
                placed = true;
            }

        }
    }
}
