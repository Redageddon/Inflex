using System.Collections.Generic;

public class Map
{
    public string Name { get; set; }
    public int Lives { get; set; }
    public string Song { get; set; }
    public int EnemyCount { get; set; }
    public string Background { get; set; }
    public double EndTime { get; set; }
    public List<Enemy> Enemies { get; set; }
    public List<Screen> ScreenEvents { get; set; }
    public double EarlyEnd { get; set; }
}

public class Enemy
{
    public string KillKey { get; set; }
    public double XLocation { get; set; }
    public double YLocation { get; set; }
    public double Rotation { get; set; }
    public double SpawnTime { get; set; }
}

public class Screen
{
    public int RotationSpeed { get; set; }
    public int Zoom { get; set; }
    public double SpawnTime { get; set; }
}