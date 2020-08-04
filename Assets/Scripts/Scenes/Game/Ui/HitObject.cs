using Audio;
using SceneLessLogic;
using SceneLessLogic.Beatmaps.Events;
using Scenes.Game.Logic;
using Ui;
using UnityEngine;

namespace Scenes.Game.Ui
{
    public class HitObject : VisibleElement
    {
        [SerializeField] private Sprite[]          sprites;

        public LocationHandler LocationHandler { get; private set; }
        public int             KillKey         { get; private set; }

        public void Ctor(EnemyEvent self, float speed)
        {
            this.Image.texture   = this.sprites[self.KillKey].texture;
            this.LocationHandler = new LocationHandler(speed, self.SpawnTime, self.Rotation, Assets.Instance.Settings.ElementsSize);
            this.KillKey         = self.KillKey;
        }

        private void Update()
        {
            this.gameObject.transform.localPosition = this.LocationHandler.GetLocation(AudioPlayer.Instance.TrueAudioTime);
            if (this.LocationHandler.AtCenter())
            {
                HitObjectHandler.OnHit(this);
            }
        }
    }
}