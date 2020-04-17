using UnityEngine;

public class AudioPlayer : Singleton<AudioPlayer>
{
    private AudioSource audioSource;

    public void PlayAudio() => audioSource.Play();
    private void Awake() => audioSource = gameObject.AddComponent<AudioSource>();
    public float TrueAudioTime => AudioHelper.CalculateTrueAudioTime(audioSource);
    public void LoadAudio(string path) => audioSource.clip = JsonLoader.LoadAudioClip(path);
    public void PlayGameSong() => StartCoroutine(AudioHelper.PlayGameSong(audioSource));

    public void SetAudioPaused(bool isPaused)
    {
        if (isPaused) audioSource.Pause();
        else audioSource.UnPause();
    }
}