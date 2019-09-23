using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
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
        Debug.Log(player.spawnedPlayer.transform.rotation);
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
                    if (time > 1f)
                    {
                        //tweens.PlayerWalk(player.spawnedPlayer);
                        time = 0;
                    }
                    playerMove.PlayerMoveTo(player.spawnedPlayer, spawnedToy.transform.position);
                    if (t > 3)
                    {
                        playerState = PlayerState.Play;
                    }
                }
                if (spawnedFood != null)
                {
                    //if (time > 0.5f)
                    //{
                    //    tweens.PlayerWalk(player.spawnedPlayer);
                    //    time = 0;
                    //}

                    playerMove.PlayerMoveTo(player.spawnedPlayer, spawnedFood.transform.position);
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

                if (t < 6)
                {
                    if (time > 1)
                    {
                        Sequence mySequence1 = DOTween.Sequence();
                        mySequence1.Append(player.spawnedPlayer.transform.DORotate(new Vector3(60f, 0f, 0f), 0.1f).SetLoops(1, LoopType.Restart));
                        mySequence1.PrependInterval(0.1f);
                        mySequence1.Append(player.spawnedPlayer.transform.DORotate(new Vector3(0f, 0f, 0f), 0.1f));
                        mySequence1.PrependInterval(0.1f);
                        mySequence1.Append(player.spawnedPlayer.transform.DORotate(new Vector3(60f, 0f, 0f), 0.1f).SetLoops(1, LoopType.Restart));
                        mySequence1.PrependInterval(0.1f);
                        mySequence1.Append(player.spawnedPlayer.transform.DORotate(new Vector3(0f, 0f, 0f), 0.1f));
                        mySequence1.PrependInterval(0.1f);
                        mySequence1.Append(player.spawnedPlayer.transform.DORotate(new Vector3(player.transform.localRotation.x, player.transform.localRotation.y, player.transform.localRotation.z), 0.1f));
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
