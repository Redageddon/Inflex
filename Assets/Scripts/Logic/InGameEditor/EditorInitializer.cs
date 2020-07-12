using Beatmaps;
using UnityEngine;

namespace Logic.InGameEditor
{
    public class EditorInitializer : MonoBehaviour
    {
        public static string Path { get; set; }
        public static bool IsExistingBeatMap { get; set; }
        public static BeatMap BeatMap { get; private set; } = new BeatMap();
        [SerializeField] private GameObject editorHolder;

        private void Awake()
        {
            if (IsExistingBeatMap)
            {
                BeatMap = FileLoader.LoadBeatMap(Path);
                this.gameObject.GetComponent<EditorConstructor>().Fill(BeatMap);
            }
            else
            {
                this.editorHolder.SetActive(true);
            }
        }
    }
}