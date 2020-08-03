using System.Collections.Generic;
using Beatmaps.Events;

namespace Beatmaps
{
    public class BeatMapMeta : BeatMapMetadata
    {
        public int Lives { get; set; }

        public string Background { get; set; }

        public List<EnemyEvent> Enemies { get; set; } = new List<EnemyEvent>(); 
    }
}