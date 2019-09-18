using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
public class Food : MonoBehaviour
{
    public GameObject food;
    public Vector3 objectPosition;
    public Quaternion objectRotation;
    public void SpawnObject(TrackableHit hit)
    {
        food = Instantiate(food, hit.Pose.position, hit.Pose.rotation);
    }

    public void UpdateFood()
    {
        food.transform.position = objectPosition;
        food.transform.rotation = objectRotation;
    }

}
