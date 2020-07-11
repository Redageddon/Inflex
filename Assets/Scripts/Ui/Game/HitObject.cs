using Audio;
using Beatmaps;
using Beatmaps.Events;
using Logic;
using Logic.Creators;
using UnityEngine;

namespace Ui.Game
{
    public class HitObject : VisibleElement
    {
        [SerializeField] private CircleCollider2D circleCollider2D;
        [SerializeField] private Sprite[] sprites;
        [SerializeField] private GameObject judgementGameObject;
        private HitObjectLocationManager locationManager;
        private float speed;
        
        public int KillKey { get; private set; }

        public void Construct(EnemyEvent enemyEvent, float speed)
        {
            this.Image.texture = this.sprites[enemyEvent.KillKey].texture;
            
            this.circleCollider2D.radius = Assets.Instance.Settings.ElementsSize;
            this.locationManager = new HitObjectLocationManager(enemyEvent);
            this.speed = speed;
            this.KillKey = enemyEvent.KillKey;

            this.SetLocation(this.locationManager.GetLocation(AudioPlayer.Instance.TrueAudioTime, this.speed));
        }

        public void Hit()
        { 
            Judgement judgement = Instantiate(this.judgementGameObject, this.transform.parent.parent).GetComponent<Judgement>();
            judgement.AssignValue(this.locationManager.Rotation);
            this.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (this.locationManager.Distance <= 2.71 * Assets.Instance.Settings.ElementsSize)
            {
                ScoreBar.Score -= 1;
                this.Hit();
            }

            this.SetLocation(this.locationManager.GetLocation(AudioPlayer.Instance.TrueAudioTime, this.speed));
        }

        private void SetLocation(Vector3 location) => this.gameObject.transform.localPosition = location;
    }
}