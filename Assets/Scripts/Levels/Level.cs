using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Level
{
    public Level(string path, int lives, string songFile, string background, string title, string artist, string creator, string icon,
        List<EnemyEvent> enemies, List<SpeedEvent> speeds, List<ScreenEvent> screenEvents)
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

        if (speeds[0].Speed != 0) speeds.Insert(0, new SpeedEvent(100, 0));

        Speeds = speeds;
        ScreenEvents = screenEvents;
    }

    [Key] public int Id { get; set; }
    public string Path { get; }
    public int Lives { get; }
    public string SongFile { get; }
    public string Background { get; }
    public string Title { get; }
    public string Artist { get; }
    public string Creator { get; }
    public string Icon { get; }
    public List<EnemyEvent> Enemies { get; }
    public List<SpeedEvent> Speeds { get; }
    public List<ScreenEvent> ScreenEvents { get; }
    
    public override string ToString() => $"{nameof(Path)}: {Path}, {nameof(Lives)}: {Lives}, {nameof(SongFile)}: {SongFile}, {nameof(Background)}: {Background}, {nameof(Title)}: {Title}, {nameof(Artist)}: {Artist}, {nameof(Creator)}: {Creator}, {nameof(Icon)}: {Icon}, {nameof(Enemies)}: {Enemies}, {nameof(Speeds)}: {Speeds}, {nameof(ScreenEvents)}: {ScreenEvents}";

}