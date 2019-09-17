using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public abstract class ObjectSpawnHandler : MonoBehaviour
{
    public GameObject spawnedObject;
    public Vector3 objectPosition;
    public Quaternion objectRotation;

    public void SpawnObject(TrackableHit hit)
    {
    }

}
