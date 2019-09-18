using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeTestTween : MonoBehaviour
{
    float width;
    float height;

	bool loopTween = true;

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

		// Changes scale on cube
		Sequence mySequence = DOTween.Sequence();
		mySequence.Append(transform.DOScale(new Vector3(width, transform.localScale.y / 5, transform.localScale.z), 0.1f));
		mySequence.PrependInterval(0.1f);
		mySequence.Append(transform.DOScale(new Vector3(width, height + 1f, transform.localScale.z), 0.1f));
		mySequence.PrependInterval(0.1f);
		mySequence.Append(transform.DOScale(new Vector3(width, transform.localScale.y / 5, transform.localScale.z), 0.1f));
		mySequence.PrependInterval(0.1f);
		mySequence.Append(transform.DOScale(new Vector3(width, height + 1f, transform.localScale.z), 0.1f));
		mySequence.PrependInterval(0.1f);
		mySequence.Append(transform.DOScale(new Vector3(width, height, transform.localScale.z), 0.1f));

		// Eating Chicken
		Sequence mySequence1 = DOTween.Sequence();
		mySequence1.Append(transform.DORotate(new Vector3(60f, 90f, 0f), 0.1f).SetLoops(1, LoopType.Restart));
		mySequence1.PrependInterval(0.1f);
		mySequence1.Append(transform.DORotate(new Vector3(0f, 90f, 0f), 0.1f));
		mySequence1.PrependInterval(0.1f);
		mySequence1.Append(transform.DORotate(new Vector3(60f, 90f, 0f), 0.1f).SetLoops(1, LoopType.Restart));
		mySequence1.PrependInterval(0.1f);
		mySequence1.Append(transform.DORotate(new Vector3(0f, 90f, 0f), 0.1f));
		mySequence1.PrependInterval(0.1f);

		// Walking Chicken
		Sequence mySequence2 = DOTween.Sequence();
		mySequence2.Append(transform.DORotate(new Vector3(0f, 90f, 20f), 0.3f).SetLoops(1, LoopType.Restart));
		mySequence2.PrependInterval(0.1f);
		mySequence2.Append(transform.DORotate(new Vector3(15f, 90f, 0f), 0.3f).SetLoops(1, LoopType.Restart));
		mySequence2.PrependInterval(0.1f);
		mySequence2.Append(transform.DORotate(new Vector3(0f, 90f, -20f), 0.3f).SetLoops(1, LoopType.Restart));
		mySequence2.PrependInterval(0.1f);
		mySequence2.Append(transform.DORotate(new Vector3(0f, 90f, 0f), 0.3f).SetLoops(1, LoopType.Restart));
		mySequence2.PrependInterval(0.1f);
	}
}
