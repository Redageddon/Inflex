public class SpeedEvent
{
    public SpeedEvent(float speed, float spawnTime)
    {
        Speed = speed;
        SpawnTime = spawnTime;
    }
    
    public float Speed { get; }
    public float SpawnTime { get; }
    
    public override string ToString() => $"{nameof(Speed)}: {Speed}, {nameof(SpawnTime)}: {SpawnTime}";
}