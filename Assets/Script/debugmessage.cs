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

    public ARRaycastManager MyArRaycastNaManager;
    

    public void Start()
    {
        msg.text = "Application Started";
        MyArRaycastNaManager = GameObject.Find("AR Session Origin").GetComponent<ARRaycastManager>();
        
    }

    public void Update()
    {
        if (Input.touchCount > 0)
        {
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            msg.text = MyArRaycastNaManager.Raycast(Input.GetTouch(0).position, hits,TrackableType.PlaneWithinPolygon).ToString();
        }
        else
        {
            msg.text = "No touch";
        }
    }
}
