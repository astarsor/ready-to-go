using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemBobber : MonoBehaviour
{
    public float bobHeight = 1f;
    public float bobDuration = 3f;

    void Start()
    {
        // Bobber();
        Sequence bobberSequence = DOTween.Sequence();
        float targetPos = transform.position.y + bobHeight;
        
        bobberSequence.Append(transform.DOMoveY(targetPos, bobDuration)).SetEase(Ease.InOutSine);
        bobberSequence.SetLoops(-1, LoopType.Yoyo).Play();
    }

    public void Bobber()
    {
        Sequence bobberSequence = DOTween.Sequence();
        float targetPos = transform.position.y + bobHeight;

        bobberSequence.Append(transform.DOMoveY(targetPos, bobDuration)).SetEase(Ease.InOutSine);
        bobberSequence.SetLoops(-1, LoopType.Yoyo).Play();

        // transform.DOPause when mouse is hovered on it
    }
    

    // DOPunchPosition for 
}
