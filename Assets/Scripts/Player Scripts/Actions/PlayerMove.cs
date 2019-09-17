using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Player
{
    float t;

    private void Start()
    {
        t = 0.3f;
    }
    public void PlayerMoveTo()
    {        //Debug.Log($"Vector 3 :{player}");
             //player.transform.Translate(Vector3.forward * Time.deltaTime);
        //Need to fix this!!! under here..
        Vector3 food = new Vector3(0, 0, 0);
        positionPlayer = Vector3.Lerp(player.transform.position, food, t);
    }

    public void RotateObjectTowardAnotherObject(Quaternion playerRotation, GameObject food, Player player)
    {
        //player.gameObject.transform.Rotate(Vector3.RotateTowards(player, foodAnchor));
        int damping = 4;
        Vector3 lookPos = food.transform.position - player.positionPlayer;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        player.rotationPlayer = Quaternion.Slerp(playerRotation, rotation, Time.deltaTime * damping);
    }
}
