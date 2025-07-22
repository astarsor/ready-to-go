using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class TransitionerSignals : MonoBehaviour
{
    public static TransitionerSignals instance;
    private Animator _animator;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip openSFX, closeSFX;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
            instance = this;
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        OpenCircle();
    }

//  ========== FOR TIMELINE SIGNAL EMITTERS ========== //
    
    // for scenechangers to use. so transition closes
    public void CloseCircleChangeScene(string goToNextScene)  
    {
        _animator.Play("CircleTransition_Close");
        _audioSource.PlayOneShot(closeSFX);
        // if (_animator.GetCurrentAnimatorStateInfo(-1).normalizedTime <= _animator.GetCurrentAnimatorStateInfo(-1).length)
        // {
        //     print("going to "+goToNextScene);
        //     // StartCoroutine(LoadScene(goToNextScene));
        //     // SceneManager.LoadScene(goToNextScene);
        // }

        StartCoroutine(LoadScene(goToNextScene));
    }
    IEnumerator LoadScene(string goToNextScene)
    {
        // yield return null;
        // AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(goToNextScene);
        // asyncOperation.allowSceneActivation = false;

        // while(!asyncOperation.isDone)
        // {
        //     if (asyncOperation.progress >= 0.9f)
        //     {
        //         asyncOperation.allowSceneActivation = true;
        //     }
        // }
        // print("current state length: " + _animator.GetCurrentAnimatorStateInfo(0).length);
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);

        SceneManager.LoadScene(goToNextScene);
    }

    public void CloseCircle() 
    {
        _animator.Play("CircleTransition_Close");
        _audioSource.PlayOneShot(closeSFX);
    }
    public void OpenCircle()
    {
        _animator.Play("CircleTransition_Open");
        _audioSource.PlayOneShot(openSFX);
    }
}
