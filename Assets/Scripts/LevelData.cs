using System.ComponentModel.DataAnnotations;

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

    [Key] public int Id { get; set; }
    public string Title { get; set; }
    public string Path { get; set; }
    public string Icon { get; set; }
    public float Difficulty { get; set; }
    public string SongFile { get; set; }

    public override string ToString() => $"Title:{Title}, Path:{Path}, Icon:{Icon}, Difficulty:{Difficulty}, SongFile:{SongFile}";
}
