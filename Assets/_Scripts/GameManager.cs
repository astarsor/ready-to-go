using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Camera _cam;
    // public GameObject mainMenuCanvas;
    public float distanceToGameScene = 8f;
    public float moveYDuration = 7f;
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

        _cam = Camera.main;
        _cam.transform.position = new Vector3 (_cam.transform.position.x, -distanceToGameScene, _cam.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        _cam.transform.DOMoveY(0, moveYDuration, true).SetEase(Ease.InElastic, 1);  //make overshoot public float 
    }
}
