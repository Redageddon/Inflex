using BeatMaps;
using BeatMaps.Events;
using Components.Loaders;
using UnityEngine;

namespace Components.InGameEditor
{
    public class EditorConstructor : MonoBehaviour
    {
        [SerializeField] private GameObject editorHolder;
        public static string Path { get; set; }
        public static bool IsNewBeatMap { get; set; } = true;
        public static BeatMap BeatMap { get; set; } = new BeatMap();

        private void Awake()
        {
            if (IsNewBeatMap)
            {
                this.editorHolder.SetActive(true);
                BeatMap.Enemies.Add(new EnemyEvent(0, 0, 0, 0));
            }
            else
            {
                BeatMap = Loader.LoadBeatMap(Path);
            }
        }
    }
}