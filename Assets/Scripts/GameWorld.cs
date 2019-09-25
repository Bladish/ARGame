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
        FindPlaceToSpawnPlayer();
    }
    
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
        toggle = !toggle;
        GameObject[] planes = GameObject.FindGameObjectsWithTag("Plane");
        for (int i = 0; i < planes.Length; i++)
        {
            planes[i].GetComponent<DetectedPlaneVisualizer>().enabled = toggle;
        }
    }
}