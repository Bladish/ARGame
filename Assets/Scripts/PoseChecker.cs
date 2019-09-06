using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System;

public class PoseChecker : MonoBehaviour
{
    public Pose pose;
    private ARRaycastManager ARRaycast;

    // Start is called before the first frame update
    void Start()
    {
        ARRaycast = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
