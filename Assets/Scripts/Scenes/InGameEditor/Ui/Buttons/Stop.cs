using Audio;
using Ui;

namespace Scenes.InGameEditor.Ui.Buttons
{
    public class Stop : MouseNavigationControl
    {
        protected override void LeftClick() => AudioPlayer.Instance.Stop();
    }
}