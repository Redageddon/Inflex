using SceneLessLogic;
using SceneLessLogic.Beatmaps;
using Ui;
using UnityEngine;

namespace Scenes.BeatmapSelection.Ui
{
    public class DeleteMapButton : MouseNavigationControl
    {
        public static GameObject      Button   { get; set; }
        public static BeatMapMetadata Metadata { get; set; }

        protected override void LeftClick() => this.DeleteMap();

        private void DeleteMap()
        {
            Destroy(Button);
            InflexContext.RemoveMap(Metadata);
            this.transform.parent.gameObject.SetActive(false);
        }
    }
}