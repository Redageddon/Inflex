using Components;

namespace Ui.Scenes.Settings.Sliders
{
    public class Volume : SliderBase
    {
        protected override float Value
        {
            get => Assets.Instance.Settings.Volume;
            set => Assets.Instance.Settings.Volume = value;
        }
    }
}