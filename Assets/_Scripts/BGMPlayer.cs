using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMPlayer : MonoBehaviour
{
    public static BGMPlayer instance;
    public AudioClip intro, loop;
    private AudioSource _audioSource;
    public AudioHighPassFilter highPassFilter;

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
    }

    void Start()
    {
        highPassFilter = GetComponent<AudioHighPassFilter>();
        highPassFilter.enabled = false;
        
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = false;
        _audioSource.clip = intro;
        _audioSource.Play();
    }

    void Update()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.clip = loop;
            _audioSource.loop = true;
            _audioSource.Play();
        }
    }
}
