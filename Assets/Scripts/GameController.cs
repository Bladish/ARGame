
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class GameController : MonoBehaviour
{
    [HideInInspector]
    public InputManager inputManager;
    [HideInInspector]
    public UIController uiController;
    [HideInInspector]
    public StateMachineManager stateMachineManager;
    public GameObject canvas;
    float t = 0;
    private GameMath gameMath;
    private TimeCalculations timeCalculations;
    public void Start()
    {
        inputManager = GetComponent<InputManager>();
        uiController = GetComponent<UIController>();
        stateMachineManager = GetComponent<StateMachineManager>();
        gameMath = GetComponent<GameMath>();
        timeCalculations = GetComponent<TimeCalculations>();

        //Making sure player and ui take damage when the game boot up. TODO Add player. 
        CallingGameMathForHungerAndHappienessLoss();

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
        stateMachineManager.StateMachineManagerUpdate(inputManager.objectSpawnHandler.spawnedFood, inputManager.objectSpawnHandler.spawnedToy, inputManager.anchorHandler.visualAnchorClone, t);



        //UI Controller
        uiController.UIControllerUpdate();

        t += Time.deltaTime;

        if(timeCalculations.GetNowTime() > timeCalculations.GetTimeRules())
        {
            //TODO Add so player take damages 
            uiController.UIMathGainAndLooseHunger(-1);
            uiController.UIMathGainAndLooseHappieness(-1);
            timeCalculations.AddTimeToTimeRules();
        }

    }

    private void RayCastAndTouchWithSpawnLogic() {
        //If touch, place main anchor at raycast, spawn player at main anchor, set player as child to anchor

        if (InstantPreviewInput.touchCount < 1 && (inputManager.touchManager.screenTouch = InstantPreviewInput.GetTouch(0)).phase != TouchPhase.Began)
        {

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
                        if (t > 2)
                        {
                            inputManager.objectSpawnHandler.SpawnFood(inputManager.rayManager.UpdateWorldRayCast(inputManager.touchManager.GetTouch()));
                            stateMachineManager.playerState = StateMachineManager.PlayerState.PlayerLook;
                            t = 0;
                        }
                        break;
                    case ButtonStateMachine.ButtonState.PLAYBUTTON:
                        if (t > 2)
                        {
                            inputManager.objectSpawnHandler.SpawnToy(inputManager.rayManager.UpdateWorldRayCast(inputManager.touchManager.GetTouch()));
                            stateMachineManager.playerState = StateMachineManager.PlayerState.PlayerLook;
                            t = 0;
                        }
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

    private void CallingGameMathForHungerAndHappienessLoss()
    {
        int happienessAndHungerLossValue = gameMath.CalculateHappienessAndHungerLoss();
        uiController.UIMathGainAndLooseHunger(-happienessAndHungerLossValue);
        uiController.UIMathGainAndLooseHappieness(-happienessAndHungerLossValue);
    }
}
