namespace Beatmaps.Events
{
    public class EnemyEvent
    {
        public EnemyEvent(int killKey, float rotation, float rotationSpeed, float spawnTime)
        {
            this.KillKey       = killKey;
            this.Rotation      = rotation;
            this.RotationSpeed = rotationSpeed;
            this.SpawnTime     = spawnTime;
        }

        public EnemyEvent()
        {
        }

        public int   KillKey       { get; set; }
        public float Rotation      { get; set; }
        public float RotationSpeed { get; set; }
        public float SpawnTime     { get; set; }

        public override string ToString() =>
            $"{nameof(this.KillKey)}: {this.KillKey}, {nameof(this.Rotation)}: {this.Rotation}, {nameof(this.RotationSpeed)}: {this.RotationSpeed}, {nameof(this.SpawnTime)}: {this.SpawnTime}";
    }
}