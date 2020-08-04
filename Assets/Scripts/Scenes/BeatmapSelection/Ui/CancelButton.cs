using Ui;

namespace Scenes.BeatmapSelection.Ui
{
    public class CancelButton : MouseNavigationControl
    {
        protected override void LeftClick() => this.transform.parent.gameObject.SetActive(false);
    }
}