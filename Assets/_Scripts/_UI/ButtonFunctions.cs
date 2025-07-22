using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        TransitionerSignals.instance.CloseCircleChangeScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
