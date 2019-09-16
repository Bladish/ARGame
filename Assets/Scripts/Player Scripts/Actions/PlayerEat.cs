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
public class PlayerEat : MonoBehaviour
{

    public void Eat()
    {

    }

    public void RotateObjectTowardAnotherObject(GameObject player, GameObject food)
    {
        //player.gameObject.transform.Rotate(Vector3.RotateTowards(player, foodAnchor));

        int damping = 4;
        var lookPos = food.transform.position - player.transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, rotation, Time.deltaTime * damping);
    }
}
