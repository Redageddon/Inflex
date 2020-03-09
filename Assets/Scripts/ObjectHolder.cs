using System.Collections.Generic;
using UnityEngine;

public class Map
{
    public string Path { get; set; }
    public int Lives { get; set; }
    public string SongFile { get; set; }
    public string Background { get; set; }
    public MapMetaData MetaData { get; set; }
    public List<Enemy> Enemies { get; set; }
    public List<SpeedEvent> Speeds { get; set; }
    public List<ScreenEvent> ScreenEvents { get; set; }
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
    public int KillKey { get; set; }
    public float SpawnDegrees { get; set; }
    public float RotationSpeed { get; set; }
    public float SpawnTime { get; set; }
}

public class SpeedEvent
{
    public float Speed { get; set; }
    public float SpawnTime { get; set; }
}

public class ScreenEvent
{
    public int RotationSpeed { get; set; }
    public int Zoom { get; set; }
    public float SpawnTime { get; set; }
}

public class SavedSettings
{
    public float Volume { get; set; }
    public List<KeyCode> Keys { get; set; }
    public Resolution Resolution { get; set; }
    public FullScreenMode ScreenMode { get; set; }
    public float CenterSize { get; set; }
}