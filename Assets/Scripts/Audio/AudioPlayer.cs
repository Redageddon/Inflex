﻿using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class AudioPlayer : MonoBehaviour
{
    public static float Difference = -5;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip blank;
    [SerializeField] private float time;
    [SerializeField] private bool constrainAudio;

    private void Start()
    {
        StartCoroutine(LoadAudio());
    }

    private IEnumerator LoadAudio()
    {
        var url = Path.Combine(GameControl.Map.Path, GameControl.Map.SongFile);
        AudioClip song;
        audioSource.name = "song";
        audioSource.volume = GlobalSettings.Settings.Volume;
        audioSource.name = GameControl.Map.SongFile;

        using (UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.UNKNOWN))
        {
            yield return request.SendWebRequest();
            song = Path.GetExtension(url) == ".mp3" ? Mp3Player.AudioClipFromMp3(request.downloadHandler.data) : DownloadHandlerAudioClip.GetContent(request);
        }

        audioSource.clip = blank;
        audioSource.Play();
        yield return new WaitWhile(() => audioSource.isPlaying);
        Difference = 0;
        audioSource.clip = song;
        audioSource.Play();
    }

    private void Update()
    {
        if (constrainAudio) audioSource.time = Mathf.Clamp(time, 0, float.PositiveInfinity);
    }
}