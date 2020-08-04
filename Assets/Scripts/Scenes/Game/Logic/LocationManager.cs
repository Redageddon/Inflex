using UnityEngine;

namespace Scenes.Game.Logic
{
    public class LocationHandler
    {
        private readonly float size;
        private readonly float spawnTime;
        private readonly float speed;
        
        public float Rotation { get; }
        public float Distance { get; private set; }

        public LocationHandler(float speed, float spawnTime, float rotation, float size)
        {
            this.speed     = speed;
            this.spawnTime = spawnTime;
            this.Rotation  = rotation;
            this.size      = size;
        }

        public Vector3 GetLocation(float audioSourceTime)
        {
            this.Distance = this.speed * (-audioSourceTime + this.spawnTime) + 5.6f * this.size;
            float radians = this.Rotation * Mathf.Deg2Rad;

            float x = this.Distance * Mathf.Sin(radians);
            float y = this.Distance * -Mathf.Cos(radians);

            return new Vector3(x, y, -1);
        }

        public bool AtCenter()
        {
            return this.Distance <= 2.71 * this.size;
        }
    }
}