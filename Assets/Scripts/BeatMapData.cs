using System;
using System.ComponentModel.DataAnnotations;
using BeatMaps;

[Serializable]
public class BeatMapData
{
    public BeatMapData()
    {
    }

    public BeatMapData(BeatMap level)
    {
        if (level == null)
        {
            throw new NullReferenceException();
        }

        this.Title = level.Title;
        this.Path = level.Path;
        this.Icon = level.Icon;
        this.Difficulty = 0;
        this.SongFile = level.SongFile;
    }

    [Key] public int Id { get; set; }

    public string Title { get; set; }

    public string Path { get; set; }

    public string Icon { get; set; }

    public float Difficulty { get; set; }

    public string SongFile { get; set; }

    public override string ToString() =>
        $"{nameof(this.Title)}: {this.Title}, {nameof(this.Path)}: {this.Path}, {nameof(this.Icon)}: {this.Icon}, {nameof(this.Difficulty)}: {this.Difficulty}, {nameof(this.SongFile)}: {this.SongFile}";
}