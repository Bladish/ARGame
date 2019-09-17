using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public Vector3 positionPlayer;
    public Quaternion rotationPlayer;
    public int hungerPoints;
    public int happyness;
    public GameObject player;
}
