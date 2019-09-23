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
    public enum PlayerState { Idle, PlayerLook, PlayerMove, Play, Eating, PlayerPlay, PlayerDie, PlayerRessurect };

    #region Managers
    [HideInInspector]
    public Player player;
    [HideInInspector]
    public PlayerState playerState;
    [HideInInspector]
    public PlayerMove playerMove;
    [HideInInspector]
    public PlayerRotate playerRotate;
    [HideInInspector]
    public PlayerEat playerEat;
    [HideInInspector]
    public PlayerPlay playerPlay;
    [HideInInspector]
    public PlayerIdle playerIdle;
    [HideInInspector]
    public Tweens tweens;
    //[HideInInspector]
    public MainAnchorHandler mainAnchorHandler;
    #endregion
    float time;

    public void Start()
    {
        #region GetComponents
        player = GetComponent<Player>();
        playerMove = GetComponent<PlayerMove>();
        playerRotate = GetComponent<PlayerRotate>();
        playerEat = GetComponent<PlayerEat>();
        playerPlay = GetComponent<PlayerPlay>();
        playerIdle = GetComponent<PlayerIdle>();
        tweens = GetComponent<Tweens>();
        mainAnchorHandler = GetComponent<MainAnchorHandler>();
        #endregion
    }

public void StateMachineManagerUpdate(GameObject spawnedFood, GameObject spawnedToy, GameObject anchor, float t)
    {
        Debug.Log(playerState);
        t += Time.deltaTime;
        time += Time.deltaTime;
        switch (playerState)
        {
            case PlayerState.Idle:
                //Make a Randomiser between diffirent AI behavior. Random Walk, random jump, random animation, random spinn, random barrelroll
                playerMove.PlayerMoveTo(player.spawnedPlayer, player.startPos);
                if(player.spawnedPlayer != null)
                playerRotate.RotateObjectTowardAnotherObject(player.spawnedPlayer, anchor);

                break;

            case PlayerState.PlayerLook:
                if (spawnedToy != null)
                {
                    if (t < 1)
                    {
                        playerRotate.RotateObjectTowardAnotherObject(player.spawnedPlayer, spawnedToy);
                    }
                    else if (t > 1)
                    {
                        playerState = PlayerState.PlayerMove;
                    }
                }
                if (spawnedFood != null)
                { 
                    if(t < 1)
                    playerRotate.RotateObjectTowardAnotherObject(player.spawnedPlayer, spawnedFood);
                    else if (t > 1)
                    
                    {
                        playerState = PlayerState.PlayerMove;
                        
                    }                
                }
                break;

            case PlayerState.PlayerMove:
                if (spawnedToy != null)
                {
                    playerMove.PlayerMoveTo(player.spawnedPlayer, spawnedToy.transform.position);
                    //When chicken has moved to food start Tween
                    //TIMER or coroutine
                    //tweens.PlayerWalk(player.spawnedPlayer);

                    if (t > 3)
                    {
                        playerState = PlayerState.Play;
                    }
                }
                if (spawnedFood != null)
                {
                    playerMove.PlayerMoveTo(player.spawnedPlayer, spawnedFood.transform.position);
                    //tweens.PlayerWalk(player.spawnedPlayer);
                    if (t > 3)
                    {                      
                        playerState = PlayerState.Eating;
                    }

                }
                break;

            case PlayerState.Play:
                //Instantiate(tweens.tweenParticle, player.spawnedPlayer.transform.position, player.spawnedPlayer.transform.rotation);
                tweens.tweenParticle.Play();
                if (t > 6)
                {
                    playerState = PlayerState.Idle;
                }
                break;

            case PlayerState.Eating:
                //tweens.PlayerPeck(player.spawnedPlayer);
                //TIMER For Pecking
                //Instantiate(tweens.tweenParticle, player.spawnedPlayer.transform.position, player.spawnedPlayer.transform.rotation);
                tweens.tweenParticle.Play();
                //tweens.tweenParticle.Stop();
                if (t < 6)
                {
                    if (time > 1)
                    {
                        tweens.PlayerPeck(player.spawnedPlayer);
                        time = 0;
                    }
                }
                else if (t > 6)
                {
                    Instantiate(tweens.tweenParticle, player.spawnedPlayer.transform.position, player.spawnedPlayer.transform.rotation);
                    playerState = PlayerState.Idle;
                }

                break;

            case PlayerState.PlayerPlay:
                break;

            case PlayerState.PlayerDie:
                tweens.PlayerScaleExplode(player.spawnedPlayer);
                break;

            case PlayerState.PlayerRessurect:
                break;
            default:
                break;
        }
    }


}
