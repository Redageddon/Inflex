using Components;
using Components.Audio;
using Components.Creators;
using Levels;
using Levels.Events;
using UnityEngine;

namespace Ui.Scenes.Game
{
    public class HitObject : VisibleElement
    {
        [SerializeField] private CircleCollider2D circleCollider2D;
        private HitObjectLocationManager locationManager;
        private float speed;
        [SerializeField] private Sprite[] sprites;

        public int KillKey { get; private set; }

        public void SetVariables(EnemyEvent enemyEvent, float speed)
        {
            this.Image.texture = Assets.Instance.Skin.HitObjects[enemyEvent.KillKey] is null
                                     ? this.sprites[enemyEvent.KillKey].texture
                                     : Assets.Instance.Skin.HitObjects[enemyEvent.KillKey];
            this.speed = speed;

            this.locationManager         = new HitObjectLocationManager(enemyEvent);
            this.KillKey                 = enemyEvent.KillKey;
            this.circleCollider2D.radius = Assets.Instance.Settings.ElementsSize;
            this.RectTransform.sizeDelta = new Vector2(Assets.Instance.Settings.ElementsSize * 2, Assets.Instance.Settings.ElementsSize * 2);

            this.gameObject.transform.localPosition = this.locationManager.GetLocation(AudioPlayer.Instance.TrueAudioTime, this.speed);
            this.gameObject.SetActive(true);
        }

        public void Hit()
        {
            JudgementCreator.Create(this.locationManager.Rotation);
            this.gameObject.SetActive(false);
        }

        public void Update() => this.UpdateLocation();

        private void UpdateLocation()
        {
            if (this.locationManager.Distance <= 2.71 * Assets.Instance.Settings.ElementsSize)
            {
                Lives.Health -= 1;
                this.Hit();
            }

            this.gameObject.transform.localPosition = this.locationManager.GetLocation(AudioPlayer.Instance.TrueAudioTime, this.speed);
        }
    }
}