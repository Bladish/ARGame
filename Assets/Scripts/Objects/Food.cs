using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
public class Food : ObjectSpawnHandler
{
    public GameObject food;
    
    public new void SpawnObject(TrackableHit hit)
    {
        food = Instantiate(food, hit.Pose.position, hit.Pose.rotation);
    }

    public void UpdateFood()
    {
        food.transform.position = objectPosition;
        food.transform.rotation = objectRotation;
    }

}
