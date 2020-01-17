using System.Collections.Generic;

public class Map
{
    public string Path { get; set; }
    public int Lives { get; set; }
    public string Song { get; set; }
    public string Background { get; set; }
    public double EndTime { get; set; }
    public MapMetaData MetaData { get; set; }
    public List<Enemy> Enemies { get; set; }
    public List<MapScreen> ScreenEvents { get; set; }
}

public class MapMetaData
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Creator { get; set; }
    public string Icon { get; set; }
}

public class Enemy
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