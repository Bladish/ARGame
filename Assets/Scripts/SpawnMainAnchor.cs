using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

/// <Author>
/// Jonathan Aronsson Olsson
/// </Author>
/// <summary>
/// Create main anchor wich all the spawnobject will connect to
/// </summary>
/// 
public class SpawnMainAnchor : MonoBehaviour
{
    public GameObject anchor;
    private Anchor mainAnchor;

    public void SpawnAnchor(TrackableHit anchorHit)
    {
        Instantiate(anchor, anchorHit.Pose.position, anchorHit.Pose.rotation);
        mainAnchor = anchorHit.Trackable.CreateAnchor(anchorHit.Pose);
        anchor.transform.parent = mainAnchor.transform;
    }
}
