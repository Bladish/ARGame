using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using System;

public class GameWorld : MonoBehaviour
{
    public GameObject player;
    public GameObject DetectedPlanePrefab;

    void Start()
    {
        
    }

    public void UpdateGameWorld()
    {
        FindPlaceToSpawnPlayer();
    }

    private void FindPlaceToSpawnPlayer()
    {
        
    }
}
