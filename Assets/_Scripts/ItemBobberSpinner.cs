using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemBobberSpinner : MonoBehaviour
{
    private Vector3 originalPos;
    public float bobHeight = 1f;
    public float bobDuration = 3f;
    public float overshoot = 5;
    void Awake()
    {
        // transform.position = originalPos;
        BobberAndSpinner(); //calling it here for now for testing
    }

    private void BobberAndSpinner()
    {
        transform.DOMoveY(bobHeight, bobDuration)
            .SetEase(Ease.InOutSine, overshoot);
        // transform.DORotate()
        // transform.DOPause when mouse is hovered on it
    }

    // DOPunchPosition for 
}
