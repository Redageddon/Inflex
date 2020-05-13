namespace Levels.Events
{
    public class SpeedEvent
    {
        public SpeedEvent(float speed, float spawnTime)
        {
            this.Speed     = speed;
            this.SpawnTime = spawnTime;
        }

        public SpeedEvent()
        {
        }

        public float Speed { get; set; }

        public float SpawnTime { get; set; }

        public override string ToString() => $"{nameof(this.Speed)}: {this.Speed}, {nameof(this.SpawnTime)}: {this.SpawnTime}";
    }
}