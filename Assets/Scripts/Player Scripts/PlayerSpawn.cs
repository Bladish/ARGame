using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;


public class PlayerSpawn : Player
{   
    [SerializeField]
    public GameObject spawnedPlayer;
    public static Player instance;

    private void Awake()
    {
        instance = this;
    }

    public void CreatePlayer(Vector3 anchorPosition, Quaternion anchorRotation)
    {
        if (spawnedPlayer == null)
        {
            positionPlayer = anchorPosition;
            rotationPlayer = anchorRotation;
            spawnedPlayer = Instantiate(player, positionPlayer, rotationPlayer);
        }
        else Debug.Log("Player " + spawnedPlayer.transform.position.ToString());
    }
    
}