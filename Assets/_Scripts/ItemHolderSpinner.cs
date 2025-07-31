using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemHolderSpinner : MonoBehaviour
{
    public float spinDuration = 5.5f;
    public Sequence spinnerSequence;

    // Start is called before the first frame update
    void Start()
    {
        // Spinner();
        spinnerSequence = DOTween.Sequence();
        Vector3 endVal = new Vector3(0, 360, 0);

        spinnerSequence.Append(transform.DORotate(endVal, spinDuration, RotateMode.LocalAxisAdd).SetEase(Ease.Linear));
        spinnerSequence.SetLoops(-1, LoopType.Restart).Play();
    }

    private bool _called = false;
    public void PauseTween()
    {
        if (_called == false)
        {
            _called = true;
            spinnerSequence.Pause();
        }
    }
    public void PlayTween()
    {
        if (_called == true)
        {
            _called = false;
            spinnerSequence.Play();
        }
    }

    // public void Spinner()
    // {

    //     Vector3 endVal = new Vector3(0, 360, 0);

    //     spinnerSequence.Append(transform.DORotate(endVal, spinDuration, RotateMode.LocalAxisAdd).SetEase(Ease.Linear));
    //     spinnerSequence.SetLoops(-1, LoopType.Restart).Play();
    // }
}
