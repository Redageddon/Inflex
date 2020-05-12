using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Level
{
    public Level(string path, int lives, string songFile, string background, string title, string artist, string creator, string icon, List<EnemyEvent> enemies, List<SpeedEvent> speeds)
    {
        Path = path;
        Lives = lives;
        SongFile = songFile;
        Background = background;
        Title = title;
        Artist = artist;
        Creator = creator;
        Icon = icon;
        Enemies = enemies;
        Speeds = speeds;
    }

    public Level() { }

    [Key] public int Id { get; set; }
    public string Path { get; set; }
    public int Lives { get; set; }
    public string SongFile { get; set; }
    public string Background { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Creator { get; set; }
    public string Icon { get; set; }
    public List<EnemyEvent> Enemies { get; set; } = new List<EnemyEvent>();
    public List<SpeedEvent> Speeds { get; set; } = new List<SpeedEvent>{new SpeedEvent(100, 0)};
    
    public override string ToString() => $"{nameof(Path)}: {Path}, {nameof(Lives)}: {Lives}, {nameof(SongFile)}: {SongFile}, {nameof(Background)}: {Background}, {nameof(Title)}: {Title}, {nameof(Artist)}: {Artist}, {nameof(Creator)}: {Creator}, {nameof(Icon)}: {Icon}, {nameof(Enemies)}: {Enemies}, {nameof(Speeds)}: {Speeds}";
}