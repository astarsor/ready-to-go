using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class BgTexScroller : MonoBehaviour
{
    public static BgTexScroller instance;
    public float speedX, speedY;

	float _uvFactor;
	Material _materialToScroll;
    private float _currentX, _currentY;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        _materialToScroll = GetComponent<MeshRenderer>().material;
        float n = _materialToScroll.GetTextureScale("_MainTex").y;
        float scale = transform.localScale.z;
        _uvFactor = n / scale;

        _currentX = _materialToScroll.mainTextureOffset.x;
        _currentY = _materialToScroll.mainTextureOffset.y;

	}
    
	void Update()
	{
        _currentX += Time.deltaTime * speedX;
        _currentY += Time.deltaTime * speedY;
        _materialToScroll.mainTextureOffset = new Vector2(_currentX, _currentY) * _uvFactor;
	}
}
