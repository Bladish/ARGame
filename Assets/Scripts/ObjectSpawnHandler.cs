using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class ObjectSpawnHandler : MonoBehaviour
{
    public GameObject food;
    public GameObject spawnedFood;
    public void SpawnFood(TrackableHit hit) {
        Debug.Log($"Spawned food at{hit.Pose.position}");
        spawnedFood = Instantiate(food, hit.Pose.position, hit.Pose.rotation);
    }
}
