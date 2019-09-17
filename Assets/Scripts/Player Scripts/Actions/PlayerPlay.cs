using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerPlay : PlayerSpawn
{
    public float width;
    public float height;
    public float playerZ;
    public float squeezeHeight;

    private void Start()
    {
        width = spawnedPlayer.transform.localScale.x;
        height = spawnedPlayer.transform.localScale.y;
        playerZ = spawnedPlayer.transform.localScale.z;
        squeezeHeight = 1/5f;
    }

    public void Play()
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
}
