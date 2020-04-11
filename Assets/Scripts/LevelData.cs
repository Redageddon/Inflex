[System.Serializable]
public class LevelData
{
    public LevelData(Level level)
    {
        Title = level.Title;
        Path = level.Path;
        Icon = level.Icon;
        Difficulty = 0;
        SongFile = level.SongFile;
    }
    
    public string Title { get; }
    public string Path { get; }
    public string Icon { get; }
    public float Difficulty { get; }
    public string SongFile { get; }
}
