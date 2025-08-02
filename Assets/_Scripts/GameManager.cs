using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

[DefaultExecutionOrder(0)]
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Camera _cam;
    private ItemsManager _itemsManager;
    public GameObject quad1, quad2;
[Space(5)]
    public int roundNum = 0;
    public int universalFPS = 24;
[Space(5)]
    public float distanceToGameScene = 12f;
    public float distanceToResultScene = 15f;
[Space(5)]
    public float moveYDuration = 7f;

    public static UnityAction OnShowResults;
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

        quad1.SetActive(true);
        quad2.SetActive(false);

        _cam = Camera.main;
        _itemsManager = GameObject.Find("Items Manager").GetComponent<ItemsManager>();
        roundNum = 0;

        _cam.transform.position = new Vector3(_cam.transform.position.x, -distanceToGameScene, _cam.transform.position.z);
    }

    public bool readyForNextRound = false;
    void Update()
    {
        if (readyForNextRound)
        {
            if (roundNum < 7)   // max rounds
            {
                roundNum++;
                Debug.Log("Proceeding to next round. Round: " + roundNum);
                _itemsManager.InstantiateSelections();
            }
            else
            {
                MoveToResults();
                OnShowResults();
            }
            readyForNextRound = false;
        }
    }
    public void ReadyNextRound()
    {
        _itemsManager.MakeRoomForNextRound();
        readyForNextRound = true;
    }

    public void MoveToGame() // called through PlayButton obj
    {
        _cam.transform.DOMoveY(0, moveYDuration)
            .SetEase(EaseFactory.StopMotion(universalFPS, Ease.InOutBack))
            .OnComplete(_itemsManager.InstantiateSelections);

        roundNum++;
    }

    public void MoveToResults() // call at end of Round 5
    {
        _cam.transform.DOMoveY(distanceToResultScene, moveYDuration)
            .SetEase(EaseFactory.StopMotion(universalFPS, Ease.InOutBack))
            .OnComplete(ShowResultsBG);
        // ^^^ call a sequence instead. that tweens the BG quad into quad2's position/rot
    }
    public void ShowResultsBG()
    {
        quad1.SetActive(false);
        quad2.SetActive(true);
    }

    public void RestartGame()   // for "again?" button on results screen
    {
        Debug.Log("RESTARTING GAME");
        _cam.transform.position = new Vector3(_cam.transform.position.x, -distanceToGameScene, _cam.transform.position.z);
        roundNum = 0;
    }
}
