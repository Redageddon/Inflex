using System.ComponentModel.DataAnnotations;

public class EnemyEvent
{
    public EnemyEvent()
    {
    }

    public EnemyEvent(int killKey, float spawnDegrees, float rotationSpeed, float spawnTime)
    {
        KillKey = killKey;
        SpawnDegrees = spawnDegrees;
        RotationSpeed = rotationSpeed;
        SpawnTime = spawnTime;
    }

    [Key] public int Id { get; set; }
    public int KillKey { get; set; }
    public float SpawnDegrees { get; set; }
    public float RotationSpeed { get; set; }
    public float SpawnTime { get; set; }
}