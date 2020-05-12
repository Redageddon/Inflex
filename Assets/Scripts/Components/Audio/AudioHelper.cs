using System.Collections;
using UnityEngine;

public class AudioHelper : MonoBehaviour
{
    public static float Offset { get; private set; }

    public static void SetOffset() => Offset = CalculateFirstHitObject();

    public static IEnumerator PlayGameSong(AudioSource audioSource)
    {
        audioSource.volume = 0;
        audioSource.Play();
        yield return new WaitUntil(() => audioSource.time >= -Offset);
        Offset = 0;
        audioSource.volume = Assets.Instance.Settings.Volume;
        audioSource.Play();
    }

    private static float CalculateFirstHitObject() => -1 * (((960 - (3.591f * Assets.Instance.Settings.ElementsSize)) /
                                                            GameState.GetSpeed(0)) - Assets.Instance.Level.Enemies[0].SpawnTime);
}