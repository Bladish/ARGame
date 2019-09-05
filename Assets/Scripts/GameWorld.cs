﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using GoogleARCore.Examples.Common;
using System;

/// <author>
/// Jonathan Aronsson Olsson
/// ARCore DetectedPlaneGenerator Template
/// </author>
/// <summary>
/// Visualize planes and save them in a list.
/// </summary>
public class GameWorld : MonoBehaviour
{
    public List<GameObject> currentPlanes = new List<GameObject>();
    public GameObject planePrefab;
    public List<DetectedPlane> planeList = new List<DetectedPlane>();
    void Start()
    {
        //planePrefab = Resources.Load("DetectedPlaneVisualizer") as GameObject;
    }

    public void UpdateGameWorld()
    {
        CheckIfMotionIsTracking();
        FindPlaceToSpawnPlayer();
    }

    private void CheckIfMotionIsTracking()
    {
        if (Session.Status != SessionStatus.Tracking)
        {
            return;
        }
    }

    private void FindPlaceToSpawnPlayer()
    {
        Session.GetTrackables<DetectedPlane>(planeList, TrackableQueryFilter.New);

        for (int i = 0; i < planeList.Count; i++)
        {
            GameObject newPlane = Instantiate(planePrefab, Vector3.zero, Quaternion.identity);
            newPlane.GetComponent<DetectedPlaneVisualizer>().Initialize(planeList[i]);

            //currentPlanes.Add(newPlane);
            //Debug.Log("Size of plane " + currentPlanes[0].transform.ToString());
        }
        //if (Input.touchCount > 1 || (Touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        //{

        //}
    }
}

//if(Frame.Raycast(Screen.height / 2, Screen.width / 2, TrackableHitFlags.PlaneWithinPolygon, out hit))
//{
//    if (hit.Trackable is DetectedPlane)
//    {

//        //Instantiate(player, hit.Pose.position, hit.Pose.rotation);
//    }
//}