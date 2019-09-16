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
    public void PlayerMoveTo(  GameObject player,  GameObject food  )
    {
        Debug.Log($"Vector 3 :{player}");
        player.transform.Translate(Vector3.forward * Time.deltaTime);
        //Vector3.Lerp(player, food, t);
    }
}
