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
        var url = Path.Combine(Assets.Instance.Level.Path, Assets.Instance.Level.SongFile);
        var clip = AudioClipLoader.Instance.Load(url);
        audioSource.volume = Assets.Instance.SavedSettings.Volume;

        audioSource.clip = blank;
        audioSource.Play();
        yield return new WaitUntil(() => audioSource.time >= -difference);
        difference = 0;
        audioSource.clip = clip;
        audioSource.Play();
    }

    private float CalculateFirstHitObject()
    {
        return -1 * ((960 - 3.591f * Assets.Instance.SavedSettings.ElementsSize) / GameState.GetSpeed(0) - Assets.Instance.Level.Enemies[0].SpawnTime);
    }
}