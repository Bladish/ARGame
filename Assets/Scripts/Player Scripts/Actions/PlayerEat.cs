using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
/// <Author>
/// Jonathan Aronsson Olsson
/// Michael Håkansson
/// </Author>
/// <summary>
/// Player eat functionality
/// </summary>
public class PlayerEat : Player
{

    public void Eat()
    {
        
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
