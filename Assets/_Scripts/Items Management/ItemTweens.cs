using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Numerics;

public class ItemTweens : MonoBehaviour
{
    public float bobHeight = 1f;
    public float bobDuration = 3f;
    public Sequence bobberSequence;
    public Sequence disposeSequence;

    void Start()
    {
        bobberSequence = DOTween.Sequence();
        float targetPos = transform.position.y + bobHeight;

        bobberSequence.Append(transform.DOMoveY(targetPos, bobDuration).SetEase(Ease.InOutSine))
            .SetLoops(-1, LoopType.Yoyo)
            .SetLink(gameObject, LinkBehaviour.KillOnDestroy)
            .Play();

    // for kill
        disposeSequence = DOTween.Sequence();
        disposeSequence.Append(transform.DOScale(0, .75f).SetEase(Ease.InOutBounce))
            .SetLink(gameObject, LinkBehaviour.KillOnDestroy)
            .OnComplete(ForDisposeTween)
            .Pause();
    }
    private void ForDisposeTween()
    {
        GameManager.instance.ReadyNextRound();
        Destroy(gameObject);
    }

    private bool _called = false;
    public void PauseBobberTween()
    {
        if (_called == false)
        {
            _called = true;
            bobberSequence.Pause();
        }
    }
    public void PlayBobberTween()
    {
        if (_called == true)
        {
            _called = false;
            bobberSequence.Play();
        }
    }

    // DOPunchPosition for 
}
