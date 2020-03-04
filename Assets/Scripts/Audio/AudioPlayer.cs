﻿using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float time;
    [SerializeField] private bool constrainAudio;

    private void Start()
    {
        StartCoroutine(LoadAudio());
    }

    private IEnumerator LoadAudio()
    {
        var url = Path.Combine(GameControl.Map.Path, GameControl.Map.SongFile);
        using (UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.UNKNOWN))
        {
            yield return request.SendWebRequest();
            audioSource.clip = Path.GetExtension(url) == ".mp3" ? Mp3Player.AudioClipFromMp3(request.downloadHandler.data) : DownloadHandlerAudioClip.GetContent(request);
            audioSource.volume = GlobalSettings.Settings.Volume;
            audioSource.name = GameControl.Map.SongFile;
            audioSource.Play();
        }
    }

    private void Update()
    {
        if (constrainAudio) audioSource.time = Mathf.Clamp(time, 0, float.PositiveInfinity);
    }
}