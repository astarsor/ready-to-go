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

    void Update()
    {
        // _myTransform.rotation = Quaternion.Euler(0, 1 * Time.deltaTime * spinSpeed, 0) ;
        _myTransform.Rotate(new Vector3(0, 1, 0), spinSpeed * Time.deltaTime);
    }
}
