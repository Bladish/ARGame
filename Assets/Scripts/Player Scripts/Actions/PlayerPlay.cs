using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerPlay : MonoBehaviour
{
    Player player;
    private float width, height, playerZ;
    private float squeezeHeight;

    private void Start()
    {
        player = GetComponent<Player>();
        width = player.spawnedPlayer.transform.localScale.x;
        height = player.spawnedPlayer.transform.localScale.y;
        playerZ = player.spawnedPlayer.transform.localScale.z;
        squeezeHeight = 1/5f;
    }

    public void Play()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(player.spawnedPlayer.transform.DOScale(new Vector3(width, height - squeezeHeight, playerZ), 0.1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(player.spawnedPlayer.transform.DOScale(new Vector3(width, height + squeezeHeight, playerZ), 0.1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(player.spawnedPlayer.transform.DOScale(new Vector3(width, height - squeezeHeight, playerZ), 0.1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(player.spawnedPlayer.transform.DOScale(new Vector3(width, height + squeezeHeight, playerZ), 0.1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(player.spawnedPlayer.transform.DOScale(new Vector3(width, height, playerZ), 0.1f));
    }
}
