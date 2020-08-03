using System.Threading.Tasks;
using Logic;
using UnityEngine;

namespace Audio
{
    public class AudioPlayer : Singleton<AudioPlayer>
    {
        private AudioSource audioSource;
        private float       offset;
        private float       elementsSize;
        private float       incomingSpeed;
        private float       firstHitObjectSpawnTime;

        public float AudioTime
        {
            get => this.audioSource.time;
            set => this.audioSource.time = value;
        }

        public bool AudioPaused
        {
            get => !this.audioSource.isPlaying;
            set
            {
                if (value)
                {
                    this.audioSource.Pause();
                    Debug.Log("pause");
                }
                else
                {
                    this.audioSource.UnPause();
                    Debug.Log("unpause");
                }
            }
        }

        public float ClipLengthInSeconds => this.audioSource.clip.samples / this.audioSource.clip.frequency;

        public float TrueAudioTime => this.AudioTime + this.offset;

        public void AudioStart() => this.audioSource.Play();

        public void LoadAudio(string path)
        {
            this.audioSource.clip = FileLoader.LoadAudioClip(path);
            this.offset           = CalculateOffset(this.elementsSize, this.incomingSpeed, this.firstHitObjectSpawnTime);
        }

        public async void PlayGameAudio()
        {
            this.audioSource.volume = 0;
            this.audioSource.Play();
            await new Task(() =>
            {
                while (this.audioSource.time >= -CalculateOffset(this.elementsSize, this.incomingSpeed, this.firstHitObjectSpawnTime))
                {
                }
            });
            this.offset             = 0;
            this.audioSource.volume = Assets.Instance.Settings.Volume;
            this.audioSource.Play();
        }

        private void Awake()
        {
            this.audioSource = this.gameObject.AddComponent<AudioSource>();
            //Todo: make this execute on game start only
            this.OnGameStart();
        }

        private void OnGameStart()
        {
            this.elementsSize            = Assets.Instance.Settings.ElementsSize;
            this.incomingSpeed           = Assets.Instance.Settings.IncomingSpeed;
            this.firstHitObjectSpawnTime = Assets.Instance.BeatMapMeta.Enemies[0].SpawnTime;
        }

        private static float CalculateOffset(float elementsSize, float speed, float startObjectTime) =>
            -((960 - 3.591f * elementsSize) / speed - startObjectTime);
    }
}