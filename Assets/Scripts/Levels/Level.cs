using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Levels.Events;

namespace Levels
{
    public class Level
    {
        public Level()
        {
        }

        public Level(string path, int lives, string songFile, string background, string title, string artist, string creator, string icon,
                     List<EnemyEvent> enemies, List<SpeedEvent> speeds)
        {
            this.Path       = path;
            this.Lives      = lives;
            this.SongFile   = songFile;
            this.Background = background;
            this.Title      = title;
            this.Artist     = artist;
            this.Creator    = creator;
            this.Icon       = icon;
            this.Enemies    = enemies;
            this.Speeds     = speeds;
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

        public List<EnemyEvent> Enemies { get; set; } = new List<EnemyEvent>();

        public List<SpeedEvent> Speeds { get; set; } =
            new List<SpeedEvent> {new SpeedEvent(100, 0)};

        public override string ToString() =>
            $"{nameof(this.Path)}: {this.Path}, {nameof(this.Lives)}: {this.Lives}, {nameof(this.SongFile)}: {this.SongFile}, {nameof(this.Background)}: {this.Background}, {nameof(this.Title)}: {this.Title}, {nameof(this.Artist)}: {this.Artist}, {nameof(this.Creator)}: {this.Creator}, {nameof(this.Icon)}: {this.Icon}, {nameof(this.Enemies)}: {this.Enemies}, {nameof(this.Speeds)}: {this.Speeds}";
    }
}