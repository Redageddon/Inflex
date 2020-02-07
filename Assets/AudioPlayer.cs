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
    private SavedSettings _settings;
    
    private void Awake()
    {
        StartCoroutine(LoadAudio());
    }

    private IEnumerator LoadAudio()
    {
        _settings = GameControl.GlobalSettings;
        using (UnityWebRequest request =
            UnityWebRequestMultimedia.GetAudioClip(Path.Combine(MapButton.Map.Path, MapButton.Map.SongFile),
                AudioType.UNKNOWN))
        {
            yield return request.SendWebRequest();
            audioSource.clip = DownloadHandlerAudioClip.GetContent(request);
            audioSource.Play();
            audioSource.volume = _settings.Volume;
        }
    }

    private void Update()
    {
        if(constrainAudio) audioSource.time = Mathf.Clamp(time, 0 , Single.PositiveInfinity);
    }
}