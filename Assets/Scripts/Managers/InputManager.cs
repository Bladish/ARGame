using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
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
    private StateMachineManager stateMachineManager;
    private MainAnchorHandler anchorHandler;
    private Player player;
    public GameObject canvas;
    public ButtonStateMachine buttonStateMachine;
    public ObjectSpawnHandler objectSpawnHandler;
    TrackableHit hit;


    void Start()
    {
        rayManager = GetComponent<RaycastManager>();
        touchManager = GetComponent<TouchManager>();
        anchorHandler = GetComponent<MainAnchorHandler>();
        stateMachineManager = GetComponent<StateMachineManager>();
        buttonStateMachine = GetComponent<ButtonStateMachine>();
        objectSpawnHandler = GetComponent<ObjectSpawnHandler>();
        player = GetComponent<Player>();
        canvas.SetActive(false);
    }

    public void UpdateInputManager()
    {
        buttonStateMachine.ButtonStateMachineUpdate();
        RayCastLogic();



        //Kolla vilken buttonstate som är aktiv, ifall null är aktiv placera inte ut ett ankare

    }



    //If touch, place main anchor at raycast, spawn player at main anchor, set player as child to anchor
    #region RayCastLogic
    private void RayCastLogic() {        
        if (InstantPreviewInput.touchCount < 1 && (touchManager.screenTouch = InstantPreviewInput.GetTouch(0)).phase != TouchPhase.Began)
        {
            Debug.Log("No Touch");
        }
        else if (InstantPreviewInput.touchCount > 0 && (touchManager.screenTouch = InstantPreviewInput.GetTouch(0)).phase == TouchPhase.Began)
        {
            if (AnchorSingelton.instance == null)
            {
                anchorHandler.SpawnAnchor(rayManager.UpdateWorldRayCast(touchManager.GetTouch()));
                player.CreatPlayer(anchorHandler.mainAnchor.transform.position, anchorHandler.mainAnchor.transform.rotation);
                anchorHandler.SetAnchorAsParent(anchorHandler.visualAnchorClone);
                anchorHandler.SetAnchorAsParent(player.spawnedPlayer);
                canvas.SetActive(false);
            }
            else if (AnchorSingelton.instance != null)
            {
                canvas.SetActive(true);

                switch (buttonStateMachine.buttonState)
                {
                    case ButtonStateMachine.ButtonState.IDLEBUTTON:
                        break;
                    case ButtonStateMachine.ButtonState.FOODBUTTON:
                        objectSpawnHandler.SpawnFood(rayManager.UpdateWorldRayCast(touchManager.GetTouch()));
                        break;
                    case ButtonStateMachine.ButtonState.PLAYBUTTON:
                        break;
                    case ButtonStateMachine.ButtonState.PETBUTTON:
                        break;
                    default:
                        break;
                }
                rayManager.UpdateUnityRayCast(touchManager.screenTouch);
                if (rayManager.rayHit.collider.CompareTag("Player"))
                {
                    Debug.Log("l0l");
                }

            }
            else
            {
                canvas.SetActive(false);
                return;
            }
        }
    }
    #endregion

    public void Remove(){
            anchorHandler.DetachAnchor();
            Destroy(player.spawnedPlayer);
    }
}
