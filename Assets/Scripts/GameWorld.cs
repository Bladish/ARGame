using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using System;

public class GameWorld : MonoBehaviour
{
    TrackableHit hit;

    void Start()
    {
        
    }

    public void UpdateGameWorld()
    {
        FindPlaceToSpawnPlayer();
    }

    private void FindPlaceToSpawnPlayer()
    {
        
        if(Frame.Raycast(Screen.height / 2, Screen.width / 2, TrackableHitFlags.PlaneWithinPolygon, out hit))
        {
            if (hit.Trackable is DetectedPlane)
            {
                Player.instance.CreatPlayer(hit.Pose.position, hit.Pose.rotation);
            }
        }
    }
}


/*if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
{
    // Use hit pose and camera pose to check if hittest is from the
    // back of the plane, if it is, no need to create the anchor.
    if ((hit.Trackable is DetectedPlane) &&
        Vector3.Dot(FirstPersonCamera.transform.position - hit.Pose.position,
            hit.Pose.rotation* Vector3.up) < 0)
    {
        Debug.Log("Hit at back of the current DetectedPlane");
    }
    else
    {
        // Instantiate Andy model at the hit pose.
        var andyObject = Instantiate(AndyAndroidPrefab, hit.Pose.position, hit.Pose.rotation);

// Compensate for the hitPose rotation facing away from the raycast (i.e. camera).
andyObject.transform.Rotate(0, k_ModelRotation, 0, Space.Self);

        // Create an anchor to allow ARCore to track the hitpoint as understanding of the physical
        // world evolves.
        var anchor = hit.Trackable.CreateAnchor(hit.Pose);

// Make Andy model a child of the anchor.
andyObject.transform.parent = anchor.transform;
*/