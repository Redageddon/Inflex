using UnityEngine;

public class AudioPlayer : Singleton<AudioPlayer>
{
    private AudioSource audioSource;

    public float TrueAudioTime => this.audioSource.time + AudioHelper.Offset;

    public void PlayAudio() => this.audioSource.Play();

    public void LoadAudio(string path) => this.audioSource.clip = Loader.LoadAudioClip(path);

    public void PlayGameSong() => this.StartCoroutine(AudioHelper.PlayGameSong(this.audioSource));

    public void SetAudioPaused(bool isPaused)
    {
        if (isPaused)
        {
            this.audioSource.Pause();
        }
        else
        {
            this.audioSource.UnPause();
        }
    }

    private void Awake() => this.audioSource = this.gameObject.AddComponent<AudioSource>();
}