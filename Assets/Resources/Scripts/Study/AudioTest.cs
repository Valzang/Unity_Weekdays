using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip[] audioClips;

    void StopAndPlay(AudioClip clip)
    {
        StopSound();
        audioSource.clip = clip;
        audioSource.Play();
    }

    void StopSound()
    {
        audioSource.Stop();
    }

    void PlaySound_Loop(AudioClip clip)
    {
        if (audioSource.isPlaying)
            return;
        audioSource.loop = true;
        audioSource.clip = clip;
        //float temp = audioSource.clip.length;
        audioSource.Play();
    }
}
