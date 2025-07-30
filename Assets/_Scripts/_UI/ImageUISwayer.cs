using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ImageUISwayer : MonoBehaviour
{
    // private RectTransform _myTransform;
    public float startVal;
    public float endVal;
    public float swayDuration = 5;
    void Start()
    {
        // _myTransform = GetComponent<RectTransform>();
        Sway();
    }
    private void Sway()
    {
        Sequence swaySequence = DOTween.Sequence();
        Vector3 start = new Vector3 (0, startVal, 0);
        Vector3 end = new Vector3(0, endVal, 0);


        swaySequence.Append(transform.DORotate(start, swayDuration).SetEase(Ease.InOutSine));
        swaySequence.Append(transform.DORotate(end, swayDuration).SetEase(Ease.InOutSine));
        swaySequence.SetLoops(-1, LoopType.Restart).Play();
    }
}
