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
        void Start()
        {
            //gameWorld = GetComponent<GameWorld>();
            inputManager = GetComponent<InputManager>();
            uiController = GetComponent<UIController>();
        }

        // Update is called once per frame
        void Update()
        {
            //gameWorld.UpdateGameWorld();
            inputManager.UpdateInputManager();
        }
    }
}