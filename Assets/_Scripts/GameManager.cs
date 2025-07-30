using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[DefaultExecutionOrder(0)]
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Camera _cam;
    public int universalFPS = 24;
    [Space(5)]
    public float distanceToGameScene = 12f;
    public float distanceToResultScene = 15f;
    [Space(5)]
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
        _cam.transform.position = new Vector3(_cam.transform.position.x, -distanceToGameScene, _cam.transform.position.z);
    }


    public void MoveToGame() // called through PlayButton obj
    {
        _cam.transform.DOMoveY(0, moveYDuration).SetEase(EaseFactory.StopMotion(universalFPS, Ease.InOutBack));
    }
    public void MoveToResults()
    {
        _cam.transform.DOMoveY(distanceToResultScene, moveYDuration).SetEase(EaseFactory.StopMotion(universalFPS, Ease.InOutBack));
    }
    public void RestartGame()   // for "again?" button on results screen
    {
        Debug.Log("RESTARTING GAME");
        _cam.transform.position = new Vector3(_cam.transform.position.x, -distanceToGameScene, _cam.transform.position.z);
    }
}
