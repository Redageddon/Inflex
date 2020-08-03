using System;
using Audio;
using Beatmaps.Events;
using Logic;
using UnityEngine;

namespace Ui.Game
{
    public class HitObject : VisibleElement
    {
        [SerializeField] private Sprite[]          sprites;
        private                  Action<HitObject> test;

        public LocationManager LocationManager { get; private set; }
        public int             KillKey         { get; private set; }

        public void Constructor(EnemyEvent self, float speed, Action<HitObject> myMethodName)
        {
            this.Image.texture   = this.sprites[self.KillKey].texture;
            this.LocationManager = new LocationManager(speed, self.SpawnTime, self.Rotation);
            this.KillKey         = self.KillKey;
            this.test            = myMethodName;
        }

        private void Update()
        {
            this.gameObject.transform.localPosition = this.LocationManager.GetLocation(AudioPlayer.Instance.TrueAudioTime);
            if (this.LocationManager.Distance <= 2.71 * Assets.Instance.Settings.ElementsSize)
            {
                this.test(this);
            }
        }
    }
}