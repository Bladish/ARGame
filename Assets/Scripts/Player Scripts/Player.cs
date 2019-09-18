using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;


public class Player : MonoBehaviour
{   
    [SerializeField]
    public GameObject player;
    public static Player instance;
    public Vector3 positionPlayer;
    public Quaternion rotationPlayer;
    public GameObject spawnedPlayer;

    private void Awake()
    {
        instance = this;
    }

    public void CreatePlayer(Vector3 anchorPosition, Quaternion anchorRotation)
    {
        if (spawnedPlayer == null)
        {
            Debug.Log("WANT TO SPAWN PLAYER");
            positionPlayer = anchorPosition;
            rotationPlayer = anchorRotation;
            spawnedPlayer = Instantiate(player, positionPlayer, rotationPlayer);
        }
        else Debug.Log("Player " + spawnedPlayer.transform.position.ToString());
    }
    
    public void UpdatePlayer()
    {
        if(spawnedPlayer.transform.position != positionPlayer) spawnedPlayer.transform.position = positionPlayer;
        if(spawnedPlayer.transform.rotation != rotationPlayer) spawnedPlayer.transform.rotation = rotationPlayer;
    }

    public void SetPlayerPosition(Vector3 position)
    {
        positionPlayer = position; 
    }
}