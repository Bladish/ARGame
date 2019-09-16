using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float t;

    private void Start()
    {
        t = 0.3f;
    }
    public void PlayerMoveTo(  Vector3 player,  Vector3 food  )
    {
        Vector3.Lerp(player, food, t);
    }
}
