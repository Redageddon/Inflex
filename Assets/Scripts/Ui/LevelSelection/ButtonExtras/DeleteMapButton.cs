using Components;
using Database;
using UnityEngine;

namespace Ui.Scenes.LevelSelection.ButtonExtras
{
    public class DeleteMapButton : ButtonBase
    {
        [SerializeField] private GameObject deletionButton;
        [SerializeField] private GameObject levelButtonOptions;

        public GameObject DeletionButton
        {
            get => this.deletionButton;
            set => this.deletionButton = value;
        }

        public int DeletionIndex { get; set; }

        protected override void Left() => this.DeleteMap();

        private void DeleteMap()
        {
            Destroy(this.DeletionButton);
            using (Database<BeatMapData> db = new Database<BeatMapData>("BeatMaps", GenericPaths.BeatMapsDataPath))
            {
                db.BeatMaps.Remove(db.BeatMaps.Find(this.DeletionIndex));
                db.SaveChanges();
            }

            this.levelButtonOptions.SetActive(false);
        }
    }
}