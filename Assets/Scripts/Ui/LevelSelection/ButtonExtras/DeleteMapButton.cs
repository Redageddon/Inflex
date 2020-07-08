using Beatmaps;
using Database;
using UnityEngine;

namespace Ui.LevelSelection.ButtonExtras
{
    public class DeleteMapButton : MouseNavigationControl
    {
        public static GameObject Button { get; set; }
        public static BeatMapData Data { get; set; }

        protected override void LeftClick() => this.DeleteMap();

        private void DeleteMap()
        {
            Destroy(Button);
            InflexContext.RemoveMap(Data);
            this.transform.parent.gameObject.SetActive(false);
        }
    }
}