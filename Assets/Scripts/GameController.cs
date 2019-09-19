namespace GoogleARCore.Examples.HelloAR
{
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class GameController : MonoBehaviour
    {
        private InputManager inputManager;
        private GameWorld gameWorld;
        private StateMachineManager playerStates;
        private ObjectSpawnHandler objectSpawnHandler;
        private UIController uIController;
        private StateMachineManager stateMachineManager;
        private UIMath uIMath;

        void Start()
        {
            inputManager = GetComponent<InputManager>();
            gameWorld = GetComponent<GameWorld>();
            playerStates = GetComponent<StateMachineManager>();
            objectSpawnHandler = GetComponent<ObjectSpawnHandler>();
            uIController = GetComponent<UIController>();
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

            if(objectSpawnHandler.foodList.Count > 0)
            {
                objectSpawnHandler.UpdateDestroyFood();
            }
            if (objectSpawnHandler.toyList.Count > 0)
            {
                objectSpawnHandler.UpdateDestroyToy();
            }
            //Hämta en buttonstate och 
            playerStates.ChangePlayerState(inputManager.buttonStateMachine.GetButtonState());
            
        }
    }
}