using Components.Audio;

namespace Ui.Scenes.InGameEditor.Buttons
{
    public class Play : ButtonBase
    {
        protected override void Left() => AudioPlayer.Instance.Play();
    }
}