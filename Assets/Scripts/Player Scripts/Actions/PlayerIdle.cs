using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : MonoBehaviour
{
    public void Idle()
    {

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
