using System;
using Beatmaps.Events;
using Logic;
using UnityEngine;

namespace Beatmaps
{
    public class HitObjectLocationManager
    {
        private readonly float deathTime;

        public HitObjectLocationManager(EnemyEvent self)
        {
            this.Rotation = self.SpawnDegrees;
            this.deathTime = self.SpawnTime;
        }

        public double Rotation { get; }

        public double Distance { get; private set; }

        public Vector3 GetLocation(float audioSourceTime, float speed)
        {
            this.Distance = speed * (-audioSourceTime + this.deathTime) + 5.6 * Assets.Instance.Settings.ElementsSize;
            double radians = this.Rotation * Mathf.Deg2Rad;

            float x = (float) (this.Distance * Math.Sin(radians));
            float y = (float) (this.Distance * -Math.Cos(radians));

            return new Vector3(x, y, -1);
        }
    }
}