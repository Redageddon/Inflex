using System.ComponentModel.DataAnnotations;

public class ScreenEvent
{
    public ScreenEvent()
    {
    }

    public ScreenEvent(int rotationSpeed, int zoom, float spawnTime)
    {
        RotationSpeed = rotationSpeed;
        Zoom = zoom;
        SpawnTime = spawnTime;
    }

    [Key] public int Id { get; set; }
    public int RotationSpeed { get; set; }
    public int Zoom { get; set; }
    public float SpawnTime { get; set; }
}