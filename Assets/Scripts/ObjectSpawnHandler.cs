using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class ObjectSpawnHandler : MonoBehaviour
{
    public GameObject spawnedFood;
    public GameObject spawnedToy;

    public List<GameObject> toyPrefabs;
    public List<GameObject> toyList;
    public List<GameObject> foodPrefabs;
    public List<GameObject> foodList;

    public float foodTimer = 3, toyTimer = 3;
    private float t = 0;

    #region Food
    public void SpawnFood(TrackableHit hit) {
        Debug.Log($"Spawned food at{hit.Pose.position}");
        int randomFood = Random.Range(0, foodPrefabs.Count);
        if (foodList.Count < 1)
        {
            spawnedFood = Instantiate(foodPrefabs[randomFood], hit.Pose.position, hit.Pose.rotation);
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
    
  
    public void UpdateDestroyToy()
    {
        t += Time.deltaTime;
        if (t > toyTimer)
        {
            Destroy(spawnedToy);
            foodList.Remove(spawnedToy);
            t = 0;
        }
    }
    #endregion
    #region Toy
    public void SpawnToy(TrackableHit hit)
    {
        Debug.Log($"Spawned food at{hit.Pose.position}");
        int randomToy = Random.Range(0, toyPrefabs.Count);
        // change lookrotation
        spawnedToy = Instantiate(toyPrefabs[randomToy], hit.Pose.position, hit.Pose.rotation) ;

    }
    #endregion
    
}
