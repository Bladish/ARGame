using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;


public class PlayerSpawn : Player
{   
    [SerializeField]
    public GameObject spawnedPlayer;
    public static Player instance;

    private void Awake()
    {
        instance = this;
    }

    public void CreatPlayer(Vector3 anchorPosition, Quaternion anchorRotation)
    {
        if (spawnedPlayer == null)
        {
            positionPlayer = anchorPosition;
            rotationPlayer = anchorRotation;
            spawnedPlayer = Instantiate(player, positionPlayer, rotationPlayer);
        }
        else Debug.Log("Player " + spawnedPlayer.transform.position.ToString());
    }

    //public void SetPlayerPosition(Vector3 position)
    //{
    //    positionPlayer = position;
    //    spawnedPlayer.transform.position = position;
    //}

    //public void SetPlayerRotation(Quaternion rotation)
    //{
    //    rotationPlayer = rotation;
    //    spawnedPlayer.transform.rotation = rotationPlayer;
    //}

    //public Vector3 GetPlayerPosition()
    //{
    //    return positionPlayer;
    //}

    //public Quaternion GetPlayerRotation()
    //{
    //    return rotationPlayer;
    //}

    public void PlayerUpdate()
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

    public void Rotate()
    {
        //spawnedPlayer.transform.DORotate(new Vector3(0, 360, 0), 2, RotateMode.FastBeyond360).SetRelative(true).SetLoops(1, LoopType.Restart).SetEase(Ease.Linear);
        //spawnedPlayer.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 3).SetRelative(true).SetLoops(-1, LoopType.Restart).SetEase(Ease.InFlash);
    }

    /*
    public void Squeeze()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(spawnedPlayer.transform.DOScale(new Vector3(width, height - squeezeHeight, playerZ), 0.1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(spawnedPlayer.transform.DOScale(new Vector3(width, height + squeezeHeight, playerZ), 0.1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(spawnedPlayer.transform.DOScale(new Vector3(width, height - squeezeHeight, playerZ), 0.1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(spawnedPlayer.transform.DOScale(new Vector3(width, height + squeezeHeight, playerZ), 0.1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(spawnedPlayer.transform.DOScale(new Vector3(width, height, playerZ), 0.1f));
    }
    */
    
}