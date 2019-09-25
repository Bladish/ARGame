using System.Collections;
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
    public Camera arCamera;
    public bool toggle;

    public void UpdateGameWorld()
    {
        //CheckIfMotionIsTracking();
        FindPlaceToSpawnPlayer();
    }

    //private void CheckIfMotionIsTracking()
    //{
    //    if (Session.Status != SessionStatus.Tracking)
    //    {
    //        return;
    //    }
    //}
    
    private void FindPlaceToSpawnPlayer()
    {
        if (toggle)
        {
            Session.GetTrackables<DetectedPlane>(planeList, TrackableQueryFilter.New);
            for (int i = 0; i < planeList.Count; i++)
            {
                GameObject newPlane = Instantiate(planePrefab, Vector3.zero, Quaternion.identity);
                newPlane.GetComponent<DetectedPlaneVisualizer>().Initialize(planeList[i]);
            }
        }
    }

    public void ToggleTracking()
    {
        // Make isSurfaceDetected to false to disable plane detection code
        toggle = !toggle;
        // Tag DetectedPlaneVisualizer prefab to Plane(or anything else)
        GameObject[] planes = GameObject.FindGameObjectsWithTag("Plane");
        // In DetectedPlaneVisualizer we have multiple polygons so we need to loop and diable DetectedPlaneVisualizer script attatched to that prefab.
        for (int i = 0; i < planes.Length; i++)
        {
            planes[i].GetComponent<DetectedPlaneVisualizer>().enabled = toggle;
        }
    }
}