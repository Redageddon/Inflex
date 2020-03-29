using System.Collections.Generic;

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