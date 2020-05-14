using Components.Loaders;
using UnityEngine;

namespace Components.Audio
{
    public class AudioPlayer : Singleton<AudioPlayer>
    {
        private AudioSource audioSource;

        public float GetClipLength => this.audioSource.clip.length;
        
        public float GetAudioTime => this.audioSource.time;
        
        public float TrueAudioTime => this.audioSource.time + AudioHelper.Offset;
        
        public bool IsPlaying() => this.audioSource.isPlaying;

        public void Play() => this.audioSource.Play();

        public void SetAudioTime(float time) => this.audioSource.time = time;
        
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
}