using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDefination : MonoBehaviour
{
    public PlayAudioEventSO playAudioEvent;//事件

    public AudioClip audioClip;//音频片段

    public bool playOnEnable;//判断是否在激活时开始播放



    //private void OnEnable()
    //{
    //    if (playOnEnable)
    //        PlayAudioClip();
    //}

    public void PlayAudioClip()
    {
        playAudioEvent.RaiseEvent(audioClip);
    }
}
