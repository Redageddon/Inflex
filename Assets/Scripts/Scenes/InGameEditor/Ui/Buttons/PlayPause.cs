using Audio;
using Ui;

namespace Scenes.InGameEditor.Ui.Buttons
{
    public class PlayPause : MouseNavigationControl
    {
        protected override void LeftClick() => AudioPlayer.Instance.AudioPaused = !AudioPlayer.Instance.AudioPaused;
    }
}