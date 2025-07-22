using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;

public class UI_Manager : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public static CanvasGroup pauseCanvasGroup;

    void Start()
    {
        pauseCanvasGroup = transform.Find("[DontRename] OnPause").GetComponent<CanvasGroup>();
        pauseCanvasGroup.alpha = 0f;

        Cursor.lockState = CursorLockMode.None;
    } 

    public static void PauseGame()
    {
        if (!gameIsPaused)
        {
            print("game paused");
            gameIsPaused = true; 

            pauseCanvasGroup.DOFade(1, 0f);     // duration set at 0 for now, or else timeScale freezes the DOFade mid transition. make coroutine in future.
            Time.timeScale = 0;            // use unscaledTime for elements that'll need to be animated/keep moving during pause screen
            // AudioListener.pause = true;    // pause all audio // would be nice to have low pass filter for all audio in pause
            BGMPlayer.instance.highPassFilter.enabled = true;
        }

        else
        {
            UnPauseGame();
        }
    }
    public static void UnPauseGame() // for continue button, in Pause Canvas
    {
        print("unpaused");
        gameIsPaused = false;

        Time.timeScale = 1;
        pauseCanvasGroup.DOFade(0, 0.25f);
        // AudioListener.pause = false;
        BGMPlayer.instance.highPassFilter.enabled = false;

    }
}
