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
    #endregion


    public void start()
    {
        #region GetComponents
        player = GetComponent<Player>();
        playerMove = GetComponent<PlayerMove>();
        playerRotate = GetComponent<PlayerRotate>();
        playerEat = GetComponent<PlayerEat>();
        playerPlay = GetComponent<PlayerPlay>();
        playerIdle = GetComponent<PlayerIdle>();
        tweens = GetComponent<Tweens>();
        #endregion
    }

public void StateMachineManagerUpdate(GameObject spawnedFood, GameObject spawnedToy)
    {
        switch (playerState)
        {
            case PlayerState.Idle:
                //Make a Randomiser between diffirent AI behavior. Random Walk, random jump, random animation, random spinn, random barrelroll
                break;

            case PlayerState.PlayerLook:
                if (spawnedToy != null)
                {
                    playerRotate.RotateObjectTowardAnotherObject(player.spawnedPlayer, spawnedToy);
                    //TIMER
                    playerState = PlayerState.PlayerMove;
                }
                if (spawnedFood != null)
                {
                    playerRotate.RotateObjectTowardAnotherObject(player.spawnedPlayer, spawnedFood);
                    playerState = PlayerState.PlayerMove;
                }
                break;

            case PlayerState.PlayerMove:
                if (spawnedToy != null)
                {
                    playerMove.PlayerMoveTo(player.spawnedPlayer, spawnedToy.transform.position);
                    //When chicken has moved to food start Tween
                    //TIMER or coroutine
                    tweens.PlayerWalk(player.spawnedPlayer);

                    playerState = PlayerState.Eating;
                }
                if (spawnedFood != null)
                {
                    playerMove.PlayerMoveTo(player.spawnedPlayer, spawnedFood.transform.position);
                    // ~~~~
                    // ~~~~
                    tweens.PlayerWalk(player.spawnedPlayer);
                    playerState = PlayerState.Eating;

                }
                break;

            case PlayerState.Play:
                break;

            case PlayerState.Eating:
                tweens.PlayerPeck(player.spawnedPlayer);
                //TIMER For Pecking
                playerState = PlayerState.Idle;
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


    public void ChangePlayerState(ButtonStateMachine.ButtonState buttonState)
    {
        if (buttonState == ButtonStateMachine.ButtonState.FOODBUTTON)
        {
            playerState = PlayerState.PlayerLook;
        }
        if (buttonState == ButtonStateMachine.ButtonState.PLAYBUTTON)
        {
            playerState = PlayerState.PlayerLook;
        }
    }

}
