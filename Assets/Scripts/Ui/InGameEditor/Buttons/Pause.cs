using Audio;

namespace Ui.InGameEditor.Buttons
{
    public class Pause : MouseNavigationControl
    {
        protected override void LeftClick() => AudioPlayer.Instance.AudioPaused = true;
    }
}