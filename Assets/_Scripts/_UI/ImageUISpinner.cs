using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageUISpinner : MonoBehaviour
{
    private RectTransform _myTransform;
    public float spinSpeed = 5;
    void Start()
    {
        _myTransform = GetComponent<RectTransform>();
    }

// make into tween. use universalFPS
    void Update()
    {
        _myTransform.Rotate(new Vector3(0, 1, 0), spinSpeed * Time.deltaTime);
    }
}
