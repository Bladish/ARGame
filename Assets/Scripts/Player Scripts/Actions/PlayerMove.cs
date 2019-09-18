using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Player
{
    float movementSpeed;

    private void Start()
    {
        //  tweak movement
        movementSpeed = Time.deltaTime * 2f;
    }
    public void PlayerMoveTo(Vector3 foodposition, Vector3 playerPosition)
    {        //Debug.Log($"Vector 3 :{player}");
        Vector3 tmp = new Vector3();     //player.transform.Translate(Vector3.forward * Time.deltaTime);
        //Need to fix this!!! under here..
        tmp = Vector3.Lerp(playerPosition, foodposition, movementSpeed);
    }

    public void RotateObjectTowardAnotherObject(Quaternion playerRotation, Vector3 foodPostion, Player player)
    {
        //player.gameObject.transform.Rotate(Vector3.RotateTowards(player, foodAnchor));
        int damping = 4;
        Vector3 lookPos = foodPostion - positionPlayer;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        player.rotationPlayer = Quaternion.Slerp(playerRotation, rotation, Time.deltaTime * damping);
    }
}
