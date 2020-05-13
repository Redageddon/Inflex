using UnityEngine;

namespace Ui.Scenes.LevelSelection.ButtonExtras
{
    public class CancelButton : ButtonBase
    {
        [SerializeField] private GameObject beatMapButtonOptions;

        protected override void Left() => this.beatMapButtonOptions.SetActive(false);
    }
}