
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
    private Save save;
    private Load load;
    private Player player;
    private ResetGame resetGame;


    public void Start()
    {
        inputManager = GetComponent<InputManager>();
        uiController = GetComponent<UIController>();
        stateMachineManager = GetComponent<StateMachineManager>();
        gameMath = GetComponent<GameMath>();
        timeCalculations = GetComponent<TimeCalculations>();
        save = GetComponent<Save>();
        load = GetComponent<Load>();
        player = GetComponent<Player>();
        resetGame = GetComponent<ResetGame>();

        if (PlayerPrefs.GetInt("CheckIfGameIsSaved") == 1)
        {
            load.LoadGameState();
            player.SetHungerAndHappienessPoints(PlayerPrefs.GetInt("Hunger"), PlayerPrefs.GetInt("Happieness"));
            uiController.uiMath.SetHungerAndHappienessUI(PlayerPrefs.GetInt("Health"), PlayerPrefs.GetInt("Happieness"));
            uiController.UIControllerUpdate();
            gameMath.GetingGameState();
            gameMath.CalculateLoadGameState();
            CallingGameMathForHungerAndHappienessLoss();
        }

        if (PlayerPrefs.GetInt("OrginalStartBool") == 1) load.LoadOrignalGameDate();

        if (PlayerPrefs.GetInt("CheckIfGameIsSaved") != 1)
        {
            SetGameStart();
        }

        if (PlayerPrefs.GetInt("OrginalStartBool") != 1) save.OrginalGameDate();

    }
   
    public void Update()
    {
        //Inputmanager
        timeCalculations.TimeCalculationsUpdate();
        SetButtonState();
        RayCastAndTouchWithSpawnLogic();
        t += Time.deltaTime;

        if (inputManager.objectSpawnHandler.foodList.Count > 0)
        {
            inputManager.objectSpawnHandler.UpdateDestroyFood();
            if (inputManager.objectSpawnHandler.t == 0)
            {
                uiController.uiMath.HungerGains(20);
                player.PlayerGainHungerPoints(20);
                save.SaveGameState(player.GetHungerPoints(), player.GetHappienessPoints(), timeCalculations.GetNowTime());
            }
        }
        if (inputManager.objectSpawnHandler.toyList.Count > 0)
        {
            inputManager.objectSpawnHandler.UpdateDestroyToy();
            if (inputManager.objectSpawnHandler.t == 0)
            {
                uiController.uiMath.HappienessGains(20);
                player.PlayerGainHappienessPoints(20);
                save.SaveGameState(player.GetHungerPoints(), player.GetHappienessPoints(), timeCalculations.GetNowTime());
            }
        }
            
        //Player stateMachine
        stateMachineManager.StateMachineManagerUpdate(inputManager.objectSpawnHandler.spawnedFood, inputManager.objectSpawnHandler.spawnedToy, inputManager.anchorHandler.visualAnchorClone, t);

        //UI Controller

        //Player And UI Update
        if (timeCalculations.GetNowTime() > timeCalculations.GetTimeRules())
        {
            player.PlayerLossHappienessPoints(1);
            player.PlayerLossHungerPoints(1);
            uiController.uiMath.HappinessLoss(1);
            uiController.uiMath.HungerLoss(1);
            save.SaveGameState(player.GetHungerPoints(), player.GetHappienessPoints(), timeCalculations.GetNowTime());
            timeCalculations.AddTimeToTimeRules();
        }

        uiController.UIControllerUpdate();

    }

    private void RayCastAndTouchWithSpawnLogic() {
        //If touch, place main anchor at raycast, spawn player at main anchor, set player as child to anchor

        if (Input.touchCount < 1 && (inputManager.touchManager.screenTouch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            
        }
        else if (Input.touchCount > 0 && (inputManager.touchManager.screenTouch = Input.GetTouch(0)).phase == TouchPhase.Began)
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
                stateMachineManager.playerState = StateMachineManager.PlayerState.Idle;
            }
        }
    }

    public void ResetGame()
    {
        resetGame.Reset(stateMachineManager.player.spawnedPlayer, inputManager.anchorHandler.visualAnchorClone, inputManager.anchorHandler.mainAnchor);
    }

    private void VisualizeCanvas(bool canvasBool) {
        canvas.SetActive(canvasBool);
    }

    private void CallingGameMathForHungerAndHappienessLoss()
    {
        int happienessAndHungerLossValue = gameMath.CalculateHappienessAndHungerLoss();
        uiController.uiMath.HappinessLoss(happienessAndHungerLossValue);
        uiController.uiMath.HungerLoss(happienessAndHungerLossValue);
        player.PlayerLossHappienessPoints(happienessAndHungerLossValue);
        player.PlayerLossHungerPoints(happienessAndHungerLossValue);
    }

    public void SetGameStart()
    {
        player.PlayerLossHungerPoints((player.GetHungerPoints() - player.GetHungerPoints()) -1);
        player.PlayerLossHappienessPoints((player.GetHappienessPoints() - player.GetHappienessPoints()) -1);
        uiController.uiMath.HappinessLoss((player.GetHappienessPoints() - player.GetHappienessPoints()) -1); ;
        uiController.uiMath.HungerLoss((player.GetHungerPoints() - player.GetHungerPoints()) -1);
        int startHappieness = Random.Range(50, 80);
        int startHunger = Random.Range(50, 80);
        player.PlayerGainHappienessPoints(startHappieness);
        player.PlayerGainHungerPoints(startHunger);
        uiController.uiMath.HungerGains(startHunger);
        uiController.uiMath.HappienessGains(startHappieness);
        uiController.UIControllerUpdate();
        save.SaveGameState(player.GetHungerPoints(), player.GetHappienessPoints(), timeCalculations.GetNowTime());
        save.OrginalGameDate();
    }

    public void SetButtonState()
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

        return;
    }
}
