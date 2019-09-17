﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <Author>
/// Michael Håkansson
/// Jonathan Aronsson Olsson
/// </Author>
/// <summary>
/// Statemachine for player actions
/// </summary>
public class StateMachineManager : MonoBehaviour
{
    public enum States { Idle, Petting, Eat, Play, LookAt };
    public States state;

    PlayerMove playerMove;
    PlayerEat playerEat;
    PlayerPlay playerPlay;
    PlayerIdle playerIdle;
    private GameObject food;
    private ObjectSpawnHandler objectHandler;

    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        playerEat = GetComponent<PlayerEat>();
        playerPlay = GetComponent<PlayerPlay>();
        playerIdle = GetComponent<PlayerIdle>();
        objectHandler = GetComponent<ObjectSpawnHandler>();
    }

    private void StateMachineUpdate()
    {
        
    }

    public void ChangePlayerState(ButtonStateMachine.ButtonState buttonState)
    {
        if (buttonState == ButtonStateMachine.ButtonState.FOODBUTTON)
        {
            state = States.Eat;
        }
    }

    public void SwitchState(PlayerSpawn player)
    {
        Debug.Log("Current state " + state.ToString());
        switch (state)
        {
            case States.Idle:
                playerIdle.Idle();
                break;

            case States.Eat:
                //playerEat.Eat();
                playerMove.RotateObjectTowardAnotherObject(player.rotationPlayer, objectHandler.spawnedFood, player);
                playerMove.PlayerMoveTo();
                break;

            case States.Play:
                playerPlay.Play();
                break;

            default:
                playerIdle.Idle();
                break;
        }
    }

}
