using UnityEngine;

namespace Ui.Scenes.LevelSelection.ButtonExtras
{
    public class CancelButton : ButtonBase
    {
        [SerializeField] private GameObject levelButtonOptions;

        protected override void Left() => this.levelButtonOptions.SetActive(false);
    }
}