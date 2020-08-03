namespace Beatmaps.Events
{
    public class ScreenEvent
    {
        public ScreenEvent(int rotationSpeed, int zoom, float spawnTime)
        {
            this.RotationSpeed = rotationSpeed;
            this.Zoom          = zoom;
            this.SpawnTime     = spawnTime;
        }

        public int RotationSpeed { get; }

        public int Zoom { get; }

        public float SpawnTime { get; }

        public override string ToString() =>
            $"{nameof(this.RotationSpeed)}: {this.RotationSpeed}, {nameof(this.Zoom)}: {this.Zoom}, {nameof(this.SpawnTime)}: {this.SpawnTime}";
    }
}