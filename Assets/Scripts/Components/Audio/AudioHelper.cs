using System.Collections;
using UnityEngine;

public class AudioHelper : MonoBehaviour
{
    private static float _offset;

    private static float CalculateFirstHitObject() => -1 * ((960 - 3.591f * Assets.Instance.Settings.ElementsSize) / 
                                                            GameState.GetSpeed(0) - Assets.Instance.Level.Enemies[0].SpawnTime);

    public static void SetOffset() => _offset = CalculateFirstHitObject();
    public static float CalculateTrueAudioTime(AudioSource audioSource) => audioSource.time + _offset;

    public static IEnumerator PlayGameSong(AudioSource audioSource)
    {
        audioSource.volume = 0;
        audioSource.Play();
        yield return new WaitUntil(() => audioSource.time >= -_offset);
        _offset = 0;
        audioSource.volume = Assets.Instance.Settings.Volume;
        audioSource.Play();
    }
}