using System.Collections.Generic;
using SceneLessLogic.Beatmaps.Events;

namespace SceneLessLogic.Beatmaps
{
    public class BeatMapMeta : BeatMapMetadata
    {
        public int Lives { get; set; }

        public string Background { get; set; }

        public List<EnemyEvent> Enemies { get; } = new List<EnemyEvent>(); 
    }
}