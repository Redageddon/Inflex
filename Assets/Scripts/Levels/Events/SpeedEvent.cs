public class SpeedEvent
{
    public SpeedEvent(float speed, float spawnTime)
    {
        Speed = speed;
        SpawnTime = spawnTime;
    }

    public SpeedEvent() { }

    public float Speed { get; set; }
    public float SpawnTime { get; set; }
    
    public override string ToString() => $"{nameof(Speed)}: {Speed}, {nameof(SpawnTime)}: {SpawnTime}";
}