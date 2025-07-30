using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemHolderSpinner : MonoBehaviour
{
    public float spinDuration = 5.5f;

    // Start is called before the first frame update
    void Start()
    {
        Spinner();

    }

    public void Spinner()
    {
        Sequence spinnerSequence = DOTween.Sequence();
        Vector3 endVal = new Vector3(0, 360, 0);

        spinnerSequence.Append(transform.DORotate(endVal, spinDuration, RotateMode.LocalAxisAdd).SetEase(Ease.Linear));
        spinnerSequence.SetLoops(-1, LoopType.Restart).Play();
    }
}
