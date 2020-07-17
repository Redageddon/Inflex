using System;
using Logic;
using UnityEngine;

namespace Ui.Game
{
    public class LocationManager
    {
        private readonly float speed;
        private readonly float spawnTime;
        private readonly float size;

        public double Rotation { get; }
        public double Distance { get; private set; }

        public LocationManager(float speed, float spawnTime, double rotation)
        {
            this.speed     = speed;
            this.spawnTime = spawnTime;
            this.Rotation  = rotation;
            this.size = Assets.Instance.Settings.ElementsSize;
        }

        public Vector3 GetLocation(float audioSourceTime)
        {
            this.Distance = this.speed * (-audioSourceTime + this.spawnTime) + 5.6 * size;
            double radians = this.Rotation * Mathf.Deg2Rad;

            float x = (float)(this.Distance * Math.Sin(radians));
            float y = (float)(this.Distance * -Math.Cos(radians));

            return new Vector3(x, y, -1);
        }
    }
}