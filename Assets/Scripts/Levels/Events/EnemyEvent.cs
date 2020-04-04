public class EnemyEvent
{
    public EnemyEvent(int killKey, float spawnDegrees, float rotationSpeed, float spawnTime)
    {
        KillKey = killKey;
        SpawnDegrees = spawnDegrees;
        RotationSpeed = rotationSpeed;
        SpawnTime = spawnTime;
    }

    public int KillKey { get;}
    public float SpawnDegrees { get;}
    public float RotationSpeed { get;}
    public float SpawnTime { get;}
}