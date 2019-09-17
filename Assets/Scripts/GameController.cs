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
        private PlayerSpawn player;
        private ButtonStateMachine buttonStateMachine;

        void Start()
        {
            gameWorld = GetComponent<GameWorld>();
            inputManager = GetComponent<InputManager>();
            uiController = GetComponent<UIController>();
            gameWorld = GetComponent<GameWorld>();
            playerStates = GetComponent<StateMachineManager>();
            player = GetComponent<PlayerSpawn>();
            buttonStateMachine = GetComponent<ButtonStateMachine>();
        }

        // Update is called once per frame
        void Update()
        {
            gameWorld.UpdateGameWorld();
            inputManager.UpdateInputManager();
            uiController.UIUpdate();
            buttonStateMachine.ButtonStateMachineUpdate();
            playerStates.ChangePlayerState(buttonStateMachine.GetButtonState());
            inputManager.RayCastLogic(player);
            //Hämta en buttonstate och 

            if (player.spawnedPlayer != null)
            {
                playerStates.SwitchState(player);
            }
            
            
        }
    }
}