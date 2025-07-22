using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemBobberSpinner : MonoBehaviour
{
    private Vector3 originalPos;
    public float bobHeight = 0.5f;
    public float bobDuration = 0.2f;
    void Awake()
    {
        transform.position = originalPos;
    }

    private void BobberAndSpinner()
    {
        transform.DOMoveY(bobHeight, bobDuration);
    }

    // DOPunchPosition for 
}
