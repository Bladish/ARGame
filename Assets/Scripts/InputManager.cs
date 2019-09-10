using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using UnityEngine.UI;
using UnityEngine.EventSystems;
/// <Author>
/// Jonathan Aronsson Olsson
/// Joakim Svensson
/// Michael Håkansson
/// </Author>
/// <summary>
/// A manager that controlls all the 
/// </summary>
public class InputManager : MonoBehaviour
{
    private RaycastManager rayManager;
    private TouchManager touchManager;
    private SpawnActor actorSpawner;
    private MainAnchorHandler anchorHandler;
    private Player player;

    TrackableHit hit;


    void Start()
    {
        rayManager = GetComponent<RaycastManager>();
        touchManager = GetComponent<TouchManager>();
        actorSpawner = GetComponent<SpawnActor>();
        anchorHandler = GetComponent<MainAnchorHandler>();
        player = GetComponent<Player>();

    }

    public void UpdateInputManager()
    {

        //If touch, place main anchor at raycast, spawn player at main anchor, set player as child to anchor
        if (InstantPreviewInput.touchCount < 1 && (touchManager.screenTouch = InstantPreviewInput.GetTouch(0)).phase != TouchPhase.Began)
        {
            Debug.Log("No Touch");
        }
        else if (InstantPreviewInput.touchCount > 0 && (touchManager.screenTouch = InstantPreviewInput.GetTouch(0)).phase == TouchPhase.Began)
        {
            if (AnchorSingelton.instance == null)
            {
                anchorHandler.SpawnAnchor(rayManager.UpdateRaycast(touchManager.GetTouch()));
                player.CreatPlayer(anchorHandler.mainAnchor.transform.position, anchorHandler.mainAnchor.transform.rotation);
                anchorHandler.SetAnchorAsParent(player.spawnedPlayer);
            }
            else
            {
                return;
            }
        }


        if (EventSystem.current.IsPointerOverGameObject(touchManager.GetTouchIndex()))
        {
            anchorHandler.DeatchAnchor();
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
