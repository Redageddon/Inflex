using System.Collections.Generic;

public class Map
{
    public string Name { get; set; }
    public int Lives { get; set; }
    public string Song { get; set; }
    public int EnemyCount { get; set; }
    public string Background { get; set; }
    public double EndTime { get; set; }
    public List<MapEnemy> Enemies { get; set; }
    public List<MapScreen> ScreenEvents { get; set; }
    public double EarlyEnd { get; set; }
}

public class MapEnemy
{
    public string KillKey { get; set; }
    public double XLocation { get; set; }
    public double YLocation { get; set; }
    public double Rotation { get; set; }
    public double SpawnTime { get; set; }
}

public class MapScreen
{
    public int RotationSpeed { get; set; }
    public int Zoom { get; set; }
    public double SpawnTime { get; set; }
}