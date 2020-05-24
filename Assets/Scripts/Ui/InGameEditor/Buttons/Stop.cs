using Components.Audio;

namespace Ui.Scenes.InGameEditor.Buttons
{
    public class Stop : ButtonBase
    {
        protected override void Left()
        {
            AudioPlayer.Instance.SetAudioPaused(true);
            AudioPlayer.Instance.SetAudioTime(0);
        }
    }
}