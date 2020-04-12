using System.Collections;
using System.IO;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public static AudioPlayer Instance { get; private set; }
    public AudioSource audioSource;
    private float difference;
    
    private void Start()
    {
        difference = CalculateFirstHitObject();
        LoadAudio();
        Instance = this;
    }

    public float TrueAudioTime()
    {
        return audioSource.time + difference;
    }

    private void LoadAudio()
    {
        var url = Path.Combine(Assets.Instance.Level.Path, Assets.Instance.Level.SongFile);
        audioSource.clip = AudioClipLoader.Load(url);
        StartCoroutine(PlayAudio());
    }

    private IEnumerator PlayAudio()
    {
        audioSource.Play();
        yield return new WaitUntil(() => audioSource.time >= -difference);
        difference = 0;
        audioSource.volume = Assets.Instance.SavedSettings.Volume;
        audioSource.Play();
    }

    private static float CalculateFirstHitObject()
    {
        return -1 * ((960 - 3.591f * Assets.Instance.SavedSettings.ElementsSize) / GameState.GetSpeed(0) - 
                     Assets.Instance.Level.Enemies[0].SpawnTime);
    }
}