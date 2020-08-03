using System;
using Logic;
using UnityEngine;

namespace Ui.Game
{
    public class LocationManager
    {
        private readonly float size;
        private readonly float spawnTime;
        private readonly float speed;

        public LocationManager(float speed, float spawnTime, double rotation)
        {
            this.speed     = speed;
            this.spawnTime = spawnTime;
            this.Rotation  = rotation;
            this.size      = Assets.Instance.Settings.ElementsSize;
        }

        public double Rotation { get; }
        public double Distance { get; private set; }

        public Vector3 GetLocation(float audioSourceTime)
        {
            this.Distance = this.speed * (-audioSourceTime + this.spawnTime) + 5.6 * this.size;
            double radians = this.Rotation * Mathf.Deg2Rad;

            float x = (float)(this.Distance * Math.Sin(radians));
            float y = (float)(this.Distance * -Math.Cos(radians));

            return new Vector3(x, y, -1);
        }
    }
}