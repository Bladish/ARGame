using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    [SerializeField]
    private GameObject player;
    private Vector3 playerPosition;
    private Quaternion playerRotation;

    public static Player instance;

    private void Awake()
    {
        instance = this;
    }

    public Player(Vector3 anchorPosition, Quaternion anchorRotation)
    {
        playerPosition = anchorPosition;
        playerRotation = anchorRotation;
        Instantiate(player, playerPosition, playerRotation);
    }

    public void SetPlayerPosition(Vector3 position)
    {
        playerPosition = position;
        player.transform.position = playerPosition;
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