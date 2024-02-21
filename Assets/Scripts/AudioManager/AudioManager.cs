using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("事件监听")]
    public PlayAudioEventSO FXEvent;

    public PlayAudioEventSO BGMEvent;

    public AudioSource BGMSource;

    public AudioSource FXSource;

    public GameObject UI;

    private UIManager UIManager;

    private void OnEnable()
    {
        FXEvent.OnEventRaised += OnFXEvent;
    }

    private void OnDisable()
    {
        FXEvent.OnEventRaised -= OnFXEvent;
    }

    private void OnFXEvent(AudioClip clip)
    {
        FXSource.clip = clip;
        FXSource.Play();
    }

    private void Start()
    {
        UIManager = UI.GetComponent<UIManager>();
    }
    private void Update()
    {
        if(!UIManager.isOpenFX)
        {
            FXSource.enabled = false;
        }
        else
        {
            FXSource.enabled = true;
        }
        if(!UIManager.isOpenBGM)
        {
            BGMSource.enabled = false;
        }
        else
        {
            BGMSource.enabled = true;
        }
    }
}
