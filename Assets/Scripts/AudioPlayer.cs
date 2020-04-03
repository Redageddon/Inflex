using System.Collections;
using System.IO;
using UnityEngine;

public class AudioPlayer : Singleton<AudioPlayer>
{
    public AudioSource audioSource;
    public AudioClip blank;

    private void Start()
    {
        StartCoroutine(LoadAudio());
    }

    public float GetTrueAudioTime()
    {
        return audioSource.time + difference;
    }

    private float difference;

    private IEnumerator LoadAudio()
    {
        difference = CalculateFirstHitObject();
        var url = Path.Combine(MapHandler.Instance.Map.Path, MapHandler.Instance.Map.SongFile);
        audioSource.volume = SettingsHandler.Instance.SavedSettings.Volume;

        audioSource.clip = blank;
        audioSource.Play();
        yield return new WaitUntil(() => audioSource.time >= -difference);
        difference = 0;
        audioSource.clip = AudioHandler.Instance.Load(url);
        audioSource.Play();
    }

    private float CalculateFirstHitObject()
    {
        return -1 * ((960 - 3.591f * SettingsHandler.Instance.SavedSettings.ElementsSize) / GameState.GetSpeed(0) - MapHandler.Instance.Map.Enemies[0].SpawnTime);
    }
}