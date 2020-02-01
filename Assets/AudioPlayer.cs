using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float time;

    private void Awake()
    {
        StartCoroutine(LoadAudio());
    }

    private IEnumerator LoadAudio()
    {
        using (UnityWebRequest request =
            UnityWebRequestMultimedia.GetAudioClip(Path.Combine(MapButton.Map.Path, MapButton.Map.SongFile),
                AudioType.UNKNOWN))
        {
            yield return request.SendWebRequest();
            audioSource.clip = DownloadHandlerAudioClip.GetContent(request);
            audioSource.Play();
        }
    }

    private void Update()
    {
        audioSource.time = time;
    }
}