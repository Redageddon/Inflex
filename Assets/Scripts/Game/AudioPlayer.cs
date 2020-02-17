using System;
using System.Collections;
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
        string url = Path.Combine(GameControl.Map.Path, GameControl.Map.SongFile);
        using (UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.UNKNOWN))
        {
            yield return request.SendWebRequest();
            audioSource.clip = Path.GetExtension(url) == ".mp3" ? NAudioPlayer.FromMp3Data(request.downloadHandler.data) : DownloadHandlerAudioClip.GetContent(request);
            audioSource.Play();
            audioSource.volume = GlobalSettings.Settings.Volume;
            audioSource.name = GameControl.Map.SongFile;
            request.Dispose();
        }
    }

    private void Update()
    {
        if (constrainAudio) audioSource.time = Mathf.Clamp(time, 0, Single.PositiveInfinity);
    }
}