using System.Collections;
using Logic;
using Logic.Loaders;
using UnityEngine;

namespace Audio
{
    public class AudioPlayer : Singleton<AudioPlayer>
    {
        public AudioSource audioSource;
        private float offset;

        public float AudioTime
        {
            get => this.audioSource.time;
            set => this.audioSource.time = value;
        }

        public float TrueAudioTime => this.AudioTime + this.offset;
        
        private void Awake() => this.audioSource = this.gameObject.AddComponent<AudioSource>();

        public void LoadAudio(string path)
        {
            this.audioSource.clip = FileLoader.LoadAudioClip(path);
            this.offset = CalculateFirstHitObject();
        }

        public void PlayGameSong() => this.StartCoroutine(this.PlayGameSong(this.audioSource));

        private IEnumerator PlayGameSong(AudioSource audioSource)
        {
            audioSource.volume = 0;
            audioSource.Play();
            yield return new WaitUntil(() => audioSource.time >= -this.offset);
            this.offset        = 0;
            audioSource.volume = Assets.Instance.Settings.Volume;
            audioSource.Play();
        }

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

        private static float CalculateFirstHitObject() => -1 * ((960 - 3.591f * Assets.Instance.Settings.ElementsSize) /
            Assets.Instance.Settings.IncomingSpeed - Assets.Instance.BeatMap.Enemies[0].SpawnTime);
    }
}