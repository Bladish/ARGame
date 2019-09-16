using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;


public class Player : MonoBehaviour
{   
    [SerializeField]
    public GameObject player;
    private Vector3 playerPosition;
    private Quaternion playerRotation;
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
            playerPosition = anchorPosition;
            playerRotation = anchorRotation;
            spawnedPlayer = Instantiate(player, playerPosition, playerRotation);
        }
        else Debug.Log("Player " + spawnedPlayer.transform.position.ToString());
    }

    /*
    public void MovePlayer(Vector3 anchorPosition)
    {
        Vector3 originPos;
        originPos = spawnedPlayer.transform.position;
        if(spawnedPlayer.transform.position == anchorPosition)
            originPos = spawnedPlayer.transform.position;
        else
            Vector3.Lerp(originPos, anchorPosition, Time.deltaTime / 5);
    }
    */

    public void SetPlayerPosition(Vector3 position)
    {
        playerPosition = position;
        spawnedPlayer.transform.position = playerPosition;
    }

    public void SetPlayerRotation(Quaternion rotation)
    {
        playerRotation = rotation;
        spawnedPlayer.transform.rotation = playerRotation;
    }

    public Vector3 GetPlayerTransform()
    {
        return playerPosition;
    }

    public Quaternion GetPlayerRotation()
    {
        return playerRotation;
    }

    private void Update()
    {
        //LookAtCamera();
    }

    //public void LookAtCamera()
    //{
    //        int damping = 4;
    //        var lookPos = Camera.main.transform.position - spawnedPlayer.transform.position;
    //        lookPos.y = 0;
    //        var rotation = Quaternion.LookRotation(lookPos);
    //        spawnedPlayer.transform.rotation = Quaternion.Slerp(spawnedPlayer.transform.rotation, rotation, Time.deltaTime * damping);          
    //}

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