using Audio;

namespace Ui.InGameEditor.Buttons
{
    public class Play : MouseNavigationControl
    {
        protected override void LeftClick() => AudioPlayer.Instance.audioSource.Play();
    }
}