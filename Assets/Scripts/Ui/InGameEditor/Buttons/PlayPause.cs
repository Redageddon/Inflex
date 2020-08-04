using Audio;

namespace Ui.InGameEditor.Buttons
{
    public class PlayPause : MouseNavigationControl
    {
        protected override void LeftClick() => AudioPlayer.Instance.AudioPaused = !AudioPlayer.Instance.AudioPaused;
    }
}