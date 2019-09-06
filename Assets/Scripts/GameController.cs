namespace GoogleARCore.Examples.HelloAR
{
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class GameController : MonoBehaviour
    {
        private GameWorld gameWorld;
        private Controller controller;
        void Start()
        {
            gameWorld = GetComponent<GameWorld>();
            controller = GetComponent<Controller>();
        }

        // Update is called once per frame
        void Update()
        {
            gameWorld.UpdateGameWorld();
            controller.UpdateController();
        }
    }
}