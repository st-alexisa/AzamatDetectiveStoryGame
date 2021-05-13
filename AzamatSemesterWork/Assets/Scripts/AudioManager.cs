using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource source;
    public AudioClip clip;
    void Start()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(PlayStartAudio());
    }

    private IEnumerator PlayStartAudio()
    {
        source.Play();
        yield return new WaitUntil(() => !source.isPlaying);
        source.clip = clip;
        source.loop = true;
        source.Play();
        yield return null;
    }
}
