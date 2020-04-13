using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Level
{
    public Level()
    {
    }

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
    public string Path { get; set; }
    public int Lives { get; set; }
    public string SongFile { get; set; }
    public string Background { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Creator { get; set; }
    public string Icon { get; set; }
    public List<EnemyEvent> Enemies { get; set; }
    public List<SpeedEvent> Speeds { get; set; }
    public List<ScreenEvent> ScreenEvents { get; set; }

    public override string ToString()
    {
        return
            $"Path:{Path}, Lives:{Lives}, SongFile:{SongFile}, Background:{Background}, Title:{Title}, Artist:{Artist}, Creator:{Creator}, Icon:{Icon}, Enemies:{Enemies.Count}, Speeds:{Speeds.Count}, ScreenEvents:{ScreenEvents}";
    }
}