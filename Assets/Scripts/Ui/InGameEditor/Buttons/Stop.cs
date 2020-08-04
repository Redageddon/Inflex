using Audio;

namespace Ui.InGameEditor.Buttons
{
    public class Stop : MouseNavigationControl
    {
        protected override void LeftClick() => AudioPlayer.Instance.Stop();
    }
}