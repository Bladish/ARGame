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
        private Player player;
        private ButtonStateMachine buttonStateMachine;
        private PlayerCamera playerCamera;
        private PlayerPlay playerPlay;

        void Start()
        {
            gameWorld = GetComponent<GameWorld>();
            inputManager = GetComponent<InputManager>();
            uiController = GetComponent<UIController>();
            gameWorld = GetComponent<GameWorld>();
            playerStates = GetComponent<StateMachineManager>();
            player = GetComponent<Player>();
            buttonStateMachine = GetComponent<ButtonStateMachine>();
            playerCamera = GetComponent<PlayerCamera>();
            playerPlay = GetComponent<PlayerPlay>();
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
            playerCamera.PlayerCameraUpdate();
            player.UpdatePlayer();
            //Hämta en buttonstate och 

            if (player.spawnedPlayer != null)
            {
                playerStates.SwitchState(player);
            }

            //if (inputManager.returnTrue() == true)
            //{
            //    playerPlay.Play();
            //    Debug.Log("HELVETE");
            //}
            
        }
    }
}