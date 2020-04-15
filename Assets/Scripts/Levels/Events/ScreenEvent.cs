public class ScreenEvent
{
    public ScreenEvent(int rotationSpeed, int zoom, float spawnTime)
    {
        RotationSpeed = rotationSpeed;
        Zoom = zoom;
        SpawnTime = spawnTime;
    }
    
    public int RotationSpeed { get; }
    public int Zoom { get; }
    public float SpawnTime { get; }
    
    public override string ToString() => $"{nameof(RotationSpeed)}: {RotationSpeed}, {nameof(Zoom)}: {Zoom}, {nameof(SpawnTime)}: {SpawnTime}";
}