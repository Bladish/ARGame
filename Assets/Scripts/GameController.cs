namespace GoogleARCore.Examples.HelloAR
{
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class GameController : MonoBehaviour
    {
        private InputManager inputManager;
        private UIController uiController;
        private GameWorld gameWorld;
        private StateMachineManager playerStates;
        private ObjectSpawnHandler objectSpawnHandler;
        private UIController uIController;
        private StateMachineManager stateMachineManager;
        private UIMath uIMath;

        void Start()
        {
            gameWorld = GetComponent<GameWorld>();
            inputManager = GetComponent<InputManager>();
            uiController = GetComponent<UIController>();
            gameWorld = GetComponent<GameWorld>();
            playerStates = GetComponent<StateMachineManager>();
            objectSpawnHandler = GetComponent<ObjectSpawnHandler>();
            uiController = GetComponent<UIController>();
            stateMachineManager = GetComponent<StateMachineManager>();
            uIMath = GetComponent<UIMath>();
        }

        // Update is called once per frame
        void Update()
        {
            stateMachineManager.StateMachineManagerUpdate();
            uIController.UIControllerUpdate();
            gameWorld.UpdateGameWorld();
            inputManager.UpdateInputManager();
            inputManager.baws.Resize(inputManager.player.spawnedPlayer, (float)uIMath.eating);
            if(objectSpawnHandler.foodList.Count > 0)
            {
                objectSpawnHandler.UpdateDestroyFood();
            }

            //Hämta en buttonstate och 
            playerStates.ChangePlayerState(inputManager.buttonStateMachine.GetButtonState());
        }
    }
}