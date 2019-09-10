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
public class SpawnMainAnchor : MonoBehaviour
{
    public Anchor mainAnchor;
    public GameObject visualAnchor;

    public void SpawnAnchor(TrackableHit anchorHit)
    {
        GameObject visualAnchorClone = Instantiate(visualAnchor, anchorHit.Pose.position, anchorHit.Pose.rotation);
        mainAnchor = anchorHit.Trackable.CreateAnchor(anchorHit.Pose);
    }
    //Child the gameobject to the anchor making it stable in the world
    public void SetAnchorAsParent(GameObject actor)
    {
        actor.transform.parent = mainAnchor.transform;
    }

    public void SetObjectAtAnchor(GameObject actor)
    {
        actor.transform.position = mainAnchor.transform.position;
    }
}
