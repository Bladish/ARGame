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

        void Start()
        {
            gameWorld = GetComponent<GameWorld>();
            inputManager = GetComponent<InputManager>();
            uiController = GetComponent<UIController>();
            gameWorld = GetComponent<GameWorld>();
            playerStates = GetComponent<StateMachineManager>();
            objectSpawnHandler = GetComponent<ObjectSpawnHandler>();
        }

        // Update is called once per frame
        void Update()
        {

            gameWorld.UpdateGameWorld();
            inputManager.UpdateInputManager();

            if(objectSpawnHandler.foodList.Count > 0)
            {
                objectSpawnHandler.UpdateDestroyFood();
            }

            //Hämta en buttonstate och 
            playerStates.ChangePlayerState(inputManager.buttonStateMachine.GetButtonState());
        }
    }
}