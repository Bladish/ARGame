namespace GoogleARCore.Examples.HelloAR
{
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class GameController : MonoBehaviour
    {
        //private GameWorld gameWorld;
        private MovementController movementController;
        private UIController uiController;
        void Start()
        {
            //gameWorld = GetComponent<GameWorld>();
            movementController = GetComponent<MovementController>();
            uiController = GetComponent<UIController>();
        }

        // Update is called once per frame
        void Update()
        {
            //gameWorld.UpdateGameWorld();
            //movementController.MovementControllerUpdate();
        }
    }
}