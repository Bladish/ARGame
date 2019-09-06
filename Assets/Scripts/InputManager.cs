using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class InputManager : MonoBehaviour
{
    private RaycastManager rayManager;
    private TouchManager touchManager;
    private SpawnActor actorSpawner;

    TrackableHit hit;

    void Start()
    {
        rayManager = GetComponent<RaycastManager>();
        touchManager = GetComponent<TouchManager>();
        actorSpawner = GetComponent<SpawnActor>();
    }

    public void UpdateInputManager()
    {
        actorSpawner.SpawnActorUpdate(rayManager.UpdateRaycast(touchManager.SendTouch()));


        touchManager.UpdateTouch();
    }

    private void MovePlayer()
    {
        Touch touch;
        if (InstantPreviewInput.touchCount < 1 || (touch = InstantPreviewInput.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }


    }

    //Debug.Log("Touched position: " + hit.Pose.position);
    //var anchor = RaycastManager.hit hit.Trackable.CreateAnchor(hit.Pose);
    //var currentAnchor = anchors[anchors.Count - 1];
    //Player.instance.SetPlayerPosition(currentAnchor.transform.position);
    //StartCoroutine("ClearAnchors");
    //public void PlacePlayer()
    //{
    //    TrackableHit hit = rayManager.ReturnHitValue();
    //    var anchor = hit.Trackable.CreateAnchor(hit.Pose);
    //    Debug.Log(anchor.transform.position);
    //}

    //public IEnumerator ClearAnchors()
    //{
    //    yield return new WaitForSeconds(2);
    //    anchors.RemoveRange(0, anchors.Count - 1);
    //    ClearAnchors();
    //}
}
