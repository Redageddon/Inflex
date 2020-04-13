using System.ComponentModel.DataAnnotations;

public class SpeedEvent
{
    public SpeedEvent()
    {
    }

    public SpeedEvent(float speed, float spawnTime)
    {
        Speed = speed;
        SpawnTime = spawnTime;
    }

    [Key] public int Id { get; set; }
    public float Speed { get; set; }
    public float SpawnTime { get; set; }
}