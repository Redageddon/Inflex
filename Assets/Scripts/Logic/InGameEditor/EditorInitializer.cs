using Beatmaps;
using UnityEngine;

namespace Logic.InGameEditor
{
    public class EditorInitializer : MonoBehaviour
    {
        [SerializeField] private GameObject  editorHolder;
        public static            string      Path              { get; set; }
        public static            bool        IsExistingBeatMap { get; set; }
        public static            BeatMapMeta BeatMapMeta       { get; private set; } = new BeatMapMeta();

        private void Awake()
        {
            if (IsExistingBeatMap)
            {
                BeatMapMeta = FileLoader.LoadBeatMap(Path);
                this.gameObject.GetComponent<EditorConstructor>().Fill(BeatMapMeta);
            }
            else
            {
                this.editorHolder.SetActive(true);
            }
        }
    }
}