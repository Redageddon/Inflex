using Components.Audio;

namespace Ui.Scenes.InGameEditor.Buttons
{
    public class Pause : ButtonBase
    {
        protected override void Left() => AudioPlayer.Instance.SetAudioPaused(true);
    }
}