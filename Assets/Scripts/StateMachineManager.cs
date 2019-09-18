using System.Collections;
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

    Player player;
    PlayerMove playerMove;
    PlayerEat playerEat;
    PlayerPlay playerPlay;
    PlayerIdle playerIdle;
    public GameObject food;
    public ObjectSpawnHandler objectHandler;

    void Start()
    {
        player = GetComponent<Player>();
        playerMove = GetComponent<PlayerMove>();
        playerEat = GetComponent<PlayerEat>();
        playerPlay = GetComponent<PlayerPlay>();
        playerIdle = GetComponent<PlayerIdle>();
        objectHandler = GetComponent<ObjectSpawnHandler>();
    }

    private void Update()
    {
        switch (state)
        {
            case States.Idle:   playerIdle.Idle();
                break;
            case States.Eat:    playerEat.Eat();
                playerEat.RotateObjectTowardAnotherObject(player.spawnedPlayer, objectHandler.spawnedFood);
                playerMove.PlayerMoveTo(player.spawnedPlayer, objectHandler.spawnedFood.transform.position);
                break;
            case States.Play:   playerPlay.Play();
                break;
            default:            playerIdle.Idle();
                break;
        }
    }


    public void ChangePlayerState(ButtonStateMachine.ButtonState buttonState)
    {
        if (buttonState == ButtonStateMachine.ButtonState.FOODBUTTON)
        {
            //playerEat
            state = States.Eat;
        }
    }

}
