using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    [SerializeField]
    public GameObject player;
    private Vector3 playerPosition;
    private Quaternion playerRotation;
    private GameObject spawnedPlayer;
    public static Player instance;
    
    private void Awake()
    {
        instance = this;
    }

    public void CreatPlayer(Vector3 anchorPosition, Quaternion anchorRotation)
    {
        if (spawnedPlayer == null)
        {
            playerPosition = anchorPosition;
            playerRotation = anchorRotation;
            spawnedPlayer = Instantiate(player, playerPosition, playerRotation);
        }
        else Debug.Log("Player " + spawnedPlayer.transform.position.ToString());
    }

    public void SetPlayerPosition(Vector3 position)
    {
        playerPosition = position;
        spawnedPlayer.transform.position = playerPosition;
    }

    public void SetPlayerRotation(Quaternion rotation)
    {
        playerRotation = rotation;
        player.transform.rotation = playerRotation;
    }

    public Vector3 GetPlayerTransform()
    {
        return playerPosition;
    }

    public Quaternion GetPlayerRotation()
    {
        return playerRotation;
    }

}