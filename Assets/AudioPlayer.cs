using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public const string aduioName = "mario.wav";

    [Header("Audio Header")] public AudioSource audioSource;
    public AudioClip audioClip;
    public string soundPath;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        soundPath = "file://" + Application.streamingAssetsPath + "/";
        StartCoroutine(LoadAudio());
    }

    private IEnumerator LoadAudio()
    {
        WWW request = GetAudioFromFile(soundPath, aduioName);
        yield return request;

        audioClip = request.GetAudioClip();
        audioClip.name = aduioName;
        PlayAudioFile();
    }

    private void PlayAudioFile()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    private WWW GetAudioFromFile(string path, string fileName)
    {
        string audioToLoad = string.Format(path + fileName);
        WWW request = new WWW(audioToLoad);
        return request;
    }


}
