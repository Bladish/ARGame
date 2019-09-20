namespace GoogleARCore.Examples.HelloAR
{
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class GameController : MonoBehaviour
    {
        
        public InputManager inputManager;
        public UIController uiController;
        public StateMachineManager stateMachineManager;
        public GameObject canvas;
        public void Start()
        {
            inputManager = GetComponent<InputManager>();
            uiController = GetComponent<UIController>();
            stateMachineManager = GetComponent<StateMachineManager>();
        }

        public void Update()
        {
            //Inputmanager
            inputManager.UpdateInputManager();
            RayCastAndTouchWithSpawnLogic();
            //if (stateMachineManager.player.spawnedPlayer == null)
            //{
            //    inputManager.baws.Resize(stateMachineManager.player.spawnedPlayer, (float)uiController.uiMath.GetEating());
            //}
            if (inputManager.objectSpawnHandler.foodList.Count > 0)
            {
                inputManager.objectSpawnHandler.UpdateDestroyFood();
            }
            if (inputManager.objectSpawnHandler.toyList.Count > 0)
            {
                inputManager.objectSpawnHandler.UpdateDestroyToy();
            }
            
            //Player stateMachine
            stateMachineManager.StateMachineManagerUpdate(inputManager.objectSpawnHandler.spawnedFood, inputManager.objectSpawnHandler.spawnedToy);

            stateMachineManager.ChangePlayerState(inputManager.buttonStateMachine.GetButtonState());

            //UI Controller
            uiController.UIControllerUpdate();
            
            

        }

        private void RayCastAndTouchWithSpawnLogic() {
            //If touch, place main anchor at raycast, spawn player at main anchor, set player as child to anchor

            if (InstantPreviewInput.touchCount < 1 && (inputManager.touchManager.screenTouch = InstantPreviewInput.GetTouch(0)).phase != TouchPhase.Began)
            {
                Debug.Log("No Touch");
            }
            else if (InstantPreviewInput.touchCount > 0 && (inputManager.touchManager.screenTouch = InstantPreviewInput.GetTouch(0)).phase == TouchPhase.Began)
            {
                if (AnchorSingelton.instance == null)
                {
                    VisualizeCanvas(true);

                    inputManager.anchorHandler.SpawnAnchor(inputManager.rayManager.UpdateWorldRayCast(inputManager.touchManager.GetTouch()));
                    if (stateMachineManager.player.spawnedPlayer == null)
                    {
                        stateMachineManager.player.CreatPlayer(inputManager.anchorHandler.mainAnchor.transform.position, inputManager.anchorHandler.mainAnchor.transform.rotation);
                    }
                    inputManager.anchorHandler.SetAnchorAsParent(inputManager.anchorHandler.visualAnchorClone);
                    inputManager.anchorHandler.SetAnchorAsParent(stateMachineManager.player.spawnedPlayer);
                }   
                else if (AnchorSingelton.instance != null)
                {
                    VisualizeCanvas(true);

                    switch (inputManager.buttonStateMachine.buttonState)
                    {
                        case ButtonStateMachine.ButtonState.IDLEBUTTON:
                            break;
                        case ButtonStateMachine.ButtonState.FOODBUTTON:
                            inputManager.objectSpawnHandler.SpawnFood(inputManager.rayManager.UpdateWorldRayCast(inputManager.touchManager.GetTouch()));
                            break;
                        case ButtonStateMachine.ButtonState.PLAYBUTTON:
                            inputManager.objectSpawnHandler.SpawnToy(inputManager.rayManager.UpdateWorldRayCast(inputManager.touchManager.GetTouch()));
                            break;
                        case ButtonStateMachine.ButtonState.PETBUTTON:
                            inputManager.rayManager.UpdateUnityRayCast(inputManager.touchManager.screenTouch);
                            if (inputManager.rayManager.UpdateUnityRayCast(inputManager.touchManager.screenTouch).transform.tag == "Player")
                            {
                                stateMachineManager.tweens.PetPlayer(stateMachineManager.player.spawnedPlayer);
                            }
                            break;
                        default:
                            break;
                    }
                    //inputManager.rayManager.UpdateUnityRayCast(inputManager.touchManager.screenTouch);
                    //if (inputManager.rayManager.rayHit.collider.CompareTag("Player"))
                    //{
                    //    Debug.Log("l0l");
                    //}

                }
                else
                {
                    VisualizeCanvas(false);
                    return;
                }
            }
        }

        //public void Remove() {
        //    anchorHandler.DetachAnchor();
        //    Destroy(player.spawnedPlayer);
        //}

        private void VisualizeCanvas(bool canvasBool) {
            canvas.SetActive(canvasBool);
        }
    }
}