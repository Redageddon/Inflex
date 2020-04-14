using System.Collections;
using System.IO;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private float offset;
    
    private void Start()
    {
        offset = CalculateFirstHitObject();
        LoadAudio();
    }

    private void LoadAudio()
    {
        string path = Path.Combine(Assets.Instance.Level.Path, Assets.Instance.Level.SongFile);
        audioSource.clip = JsonLoader.LoadAudioClip(path);
        StartCoroutine(PlayAudio());
    }

    private IEnumerator PlayAudio()
    {
        audioSource.Play();
        yield return new WaitUntil(() => audioSource.time >= -offset);
        offset = 0;
        audioSource.volume = Assets.Instance.SavedSettings.Volume;
        audioSource.Play();
    }

    public float TrueAudioTime => audioSource.time + offset; 
    
    private static float CalculateFirstHitObject() => -1 * ((960 - 3.591f * Assets.Instance.SavedSettings.ElementsSize) / GameState.GetSpeed(0) - Assets.Instance.Level.Enemies[0].SpawnTime);
    
}