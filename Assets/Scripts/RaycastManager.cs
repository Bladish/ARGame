using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

/// <Author>
/// Michael Håkansson
/// Jonathan Aronsson Olsson
/// </Author>
/// <summary>
/// Manage raycasts
/// </summary>
public class RaycastManager : MonoBehaviour
{
    private Pose pose;
    private TrackableHit hit;
    private Touch touch;
    private Vector3 hitArea;

    public void UpdateRaycastManager()
    {
        
    }

    public TrackableHit UpdateRaycast(Touch touch)
    {

        TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon | TrackableHitFlags.FeaturePointWithSurfaceNormal;
        if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
        {
            if (hit.Trackable is FeaturePoint || hit.Trackable is DetectedPlane)
            {
                if (InstantPreviewInput.touchCount > 0 && InstantPreviewInput.GetTouch(0).phase == TouchPhase.Began)
                {
                    Debug.Log("Touched position: " + hit.Pose.position);
                }
            }
        }

        return hit;
    }

}
