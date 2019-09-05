﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameWorld gameWorld;
    void Start()
    {
        gameWorld = GetComponent<GameWorld>();
    }

    // Update is called once per frame
    void Update()
    {
        gameWorld.UpdateGameWorld();
    }
}