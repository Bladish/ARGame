using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeTestTween : MonoBehaviour
{
    float width;
    float height;

    // Start is called before the first frame update
    void Start()
    {
        width = transform.localScale.x;
        height = transform.localScale.y;
        //transform.DORotate(new Vector3(0, 180, 0), 0.5f).SetLoops(-1, LoopType.Restart);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Tween();
        }
    }

    private void Tween()
    {
        //transform.DOScale(new Vector3(0.2f, -0.2f, 0), 0.5f).SetLoops(1, LoopType.);
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOScale(new Vector3(width, transform.localScale.y/5, transform.localScale.z), 0.1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(transform.DOScale(new Vector3(width, height+1f, transform.localScale.z), 0.1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(transform.DOScale(new Vector3(width, transform.localScale.y / 5, transform.localScale.z), 0.1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(transform.DOScale(new Vector3(width, height + 1f, transform.localScale.z), 0.1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(transform.DOScale(new Vector3(width, height, transform.localScale.z), 0.1f));
    }
}
