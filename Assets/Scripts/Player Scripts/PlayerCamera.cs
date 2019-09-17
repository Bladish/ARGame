using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : Player
{
    public void PlayerCameraUpdate()
    {
        LookAtCamera();
    }

    public void LookAtCamera()
    {
        int damping = 4;
        Vector3 lookPos = Camera.main.transform.position - positionPlayer;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        rotationPlayer = (Quaternion.Slerp(rotationPlayer, rotation, Time.deltaTime * damping));
    }
}
