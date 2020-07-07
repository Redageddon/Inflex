using Beatmaps;
using Database;
using Logic.Loaders;
using UnityEngine;

namespace Ui.LevelSelection.ButtonExtras
{
    public class DeleteMapButton : MouseNavigationControl
    {
        private static GameObject button;
        private static BeatMapData data;

        public static void SetDeleter(GameObject button, BeatMapData data)
        { 
            DeleteMapButton.button = button;
            DeleteMapButton.data = data;
        }

        protected override void LeftClick() => this.DeleteMap();

        private void DeleteMap()
        {
            Destroy(button);
            DatabaseLoader.Remove(data);
            this.transform.parent.gameObject.SetActive(false);
        }
    }
}