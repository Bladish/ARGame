using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class SpawnActor : MonoBehaviour
{
    public GameObject actor;
    
    public void SpawnActorUpdate(TrackableHit spawnHit)
    {
        Debug.Log("Helvete!");
        Instantiate(actor, spawnHit.Pose.position, spawnHit.Pose.rotation);
    }
}
