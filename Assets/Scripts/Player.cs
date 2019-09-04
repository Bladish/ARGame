using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    
    private Player()
    {
        if (player == null) Instantiate(player);

    }
}
