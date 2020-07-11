using System.Collections.Generic;
using Beatmaps.Events;

namespace Beatmaps
{
    public class BeatMap
    {
        public BeatMap()
        {
        }

        public BeatMap(string path, int lives, string songFile, string background, string title, string artist, string mapper, string icon,
                       List<EnemyEvent> enemies)
        {
            this.Path = path;
            this.Lives = lives;
            this.SongFile = songFile;
            this.Background = background;
            this.Title = title;
            this.Artist = artist;
            this.Mapper = mapper;
            this.Icon = icon;
            this.Enemies = enemies;
        }

        public int Id { get; set; }

        public string Path { get; set; }

        public int Lives { get; set; }

        public string SongFile { get; set; }

        public string Background { get; set; }

        public string Icon { get; set; }

        public string Title { get; set; }

        public string Artist { get; set; }

        public string Mapper { get; set; }

        public List<EnemyEvent> Enemies { get; set; } = new List<EnemyEvent>(); 
        
        public override string ToString() => $"{nameof(this.Id)}: {this.Id}, {nameof(this.Path)}: {this.Path}, {nameof(this.Lives)}: {this.Lives}, {nameof(this.SongFile)}: {this.SongFile}, {nameof(this.Background)}: {this.Background}, {nameof(this.Icon)}: {this.Icon}, {nameof(this.Title)}: {this.Title}, {nameof(this.Artist)}: {this.Artist}, {nameof(this.Mapper)}: {this.Mapper}, {nameof(this.Enemies)}: {this.Enemies}";
    }
}