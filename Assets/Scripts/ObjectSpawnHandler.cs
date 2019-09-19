using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class ObjectSpawnHandler : MonoBehaviour
{
    public GameObject spawnedFood;

    public List<GameObject> foodPrefabs;
    public List<GameObject> foodList;

    public float foodTimer = 3;
    private float t = 0;

    public void SpawnFood(TrackableHit hit) {
        Debug.Log($"Spawned food at{hit.Pose.position}");
        int randomNum = Random.Range(0, foodPrefabs.Count);
        if (foodList.Count < 1)
        {
            spawnedFood = Instantiate(foodPrefabs[randomNum], hit.Pose.position, hit.Pose.rotation);
            foodList.Add(spawnedFood);
        }
    }

    public void UpdateDestroyFood()
    {
        t += Time.deltaTime;
        if (t > foodTimer)
        {
            Destroy(spawnedFood);
            foodList.Remove(spawnedFood);
            t = 0;
        }
        
    }

}
