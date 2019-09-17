namespace GoogleARCore.Examples.HelloAR
{
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class GameController : MonoBehaviour
    {
        //private GameWorld gameWorld;
        private InputManager inputManager;
        private UIController uiController;
        private GameWorld gameWorld;
        private StateMachineManager playerStates;
        private PlayerSpawn playerSpawn;
        private ButtonStateMachine buttonStateMachine;
        private PlayerCamera playerCamera;

        void Start()
        {
            gameWorld = GetComponent<GameWorld>();
            inputManager = GetComponent<InputManager>();
            uiController = GetComponent<UIController>();
            gameWorld = GetComponent<GameWorld>();
            playerStates = GetComponent<StateMachineManager>();
            playerSpawn = GetComponent<PlayerSpawn>();
            buttonStateMachine = GetComponent<ButtonStateMachine>();
            playerCamera = GetComponent<PlayerCamera>();
        }

        // Update is called once per frame
        void Update()
        {
            gameWorld.UpdateGameWorld();
            inputManager.UpdateInputManager();
            uiController.UIUpdate();
            buttonStateMachine.ButtonStateMachineUpdate();
            playerStates.ChangePlayerState(buttonStateMachine.GetButtonState());
            inputManager.RayCastLogic(playerSpawn);
            playerCamera.PlayerCameraUpdate();
            playerSpawn.UpdatePlayer();
            //Hämta en buttonstate och 

            if (playerSpawn.spawnedPlayer != null)
            {
                playerStates.SwitchState(playerSpawn);
            }
            
            
        }
    }
}