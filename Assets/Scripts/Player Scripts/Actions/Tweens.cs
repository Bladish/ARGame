﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tweens : MonoBehaviour
{
    public ParticleSystem tweenParticle;

    float width;
    float height;
    float baseRotX, baseRotY, baseRotZ;
    float t = 1;
    Player player;

    void Start()
    {
        player = GetComponent<Player>();
        if (player.spawnedPlayer != null)
        {
            width = player.spawnedPlayer.transform.localScale.x;
            height = player.spawnedPlayer.transform.localScale.y;
            baseRotX = player.spawnedPlayer.transform.localRotation.x;
            baseRotY = player.spawnedPlayer.transform.localRotation.y;
            baseRotZ = player.spawnedPlayer.transform.localRotation.z;
        }
    }

    void Update()
    {
        t += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E) && t > 0.8f)
        {
            StartCoroutine(timeDelay());
            t = 0;
        }
    }

    private void PlayerScale(GameObject player)
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(player.transform.DOScale(new Vector3(width, player.transform.localScale.y / 5, player.transform.localScale.z), 0.1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(player.transform.DOScale(new Vector3(width, height + 1f, player.transform.localScale.z), 0.1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(player.transform.DOScale(new Vector3(width, player.transform.localScale.y / 5, player.transform.localScale.z), 0.1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(player.transform.DOScale(new Vector3(width, height + 1f, player.transform.localScale.z), 0.1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(player.transform.DOScale(new Vector3(width, height, player.transform.localScale.z), 0.1f));
    }

    public void PlayerPeck(GameObject player)
    {
        Sequence mySequence1 = DOTween.Sequence();
        mySequence1.Append(player.transform.DORotate(new Vector3(60f, 0f, 0f), 0.1f).SetLoops(1, LoopType.Restart));
        mySequence1.PrependInterval(0.1f);
        mySequence1.Append(player.transform.DORotate(new Vector3(0f, 0f, 0f), 0.1f));
        mySequence1.PrependInterval(0.1f);
        mySequence1.Append(player.transform.DORotate(new Vector3(60f, 0f, 0f), 0.1f).SetLoops(1, LoopType.Restart));
        mySequence1.PrependInterval(0.1f);
        mySequence1.Append(player.transform.DORotate(new Vector3(0f, 0f, 0f), 0.1f));
        mySequence1.PrependInterval(0.1f);
        mySequence1.Append(player.transform.DORotate(new Vector3(baseRotX, baseRotY, baseRotZ), 0.1f));
    }

    public void PlayerWalk(GameObject player)
    {
        Sequence mySequence2 = DOTween.Sequence();
        mySequence2.Append(player.transform.DORotate(new Vector3(0f, 0f, 20f), 0.2f).SetLoops(1, LoopType.Restart));
        mySequence2.PrependInterval(0.1f);
        mySequence2.Append(player.transform.DORotate(new Vector3(0f, 0f, 0f), 0.3f).SetLoops(1, LoopType.Restart));
        mySequence2.PrependInterval(0.1f);
        mySequence2.Append(player.transform.DORotate(new Vector3(0f, 0f, -20f), 0.2f).SetLoops(1, LoopType.Restart));
        mySequence2.PrependInterval(0.1f);
        mySequence2.Append(player.transform.DORotate(new Vector3(0f, 0f, 0f), 0.2f).SetLoops(1, LoopType.Restart));
        mySequence2.PrependInterval(0.1f);
        mySequence2.Append(player.transform.DORotate(new Vector3(baseRotX, baseRotY, baseRotZ), 0f));
    }

    private void PlayerScaleExplode(GameObject player)
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(player.transform.DOScale(new Vector3(width, player.transform.localScale.y / 5, player.transform.localScale.z), 0.1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(player.transform.DOScale(new Vector3(width + 1f, height + 1f, player.transform.localScale.z + 1f), 1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(player.transform.DOScale(new Vector3(width = 0f, height = 0f, 0f), 0.1f));
    }

    public IEnumerator timeDelay()
    {
        //PlayerScaleExplode();
        yield return new WaitForSeconds(1.4f);
        tweenParticle.Play();
    }
}
