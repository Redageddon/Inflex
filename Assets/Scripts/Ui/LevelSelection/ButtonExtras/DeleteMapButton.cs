using Beatmaps;
using Database;
using UnityEngine;

namespace Ui.LevelSelection.ButtonExtras
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