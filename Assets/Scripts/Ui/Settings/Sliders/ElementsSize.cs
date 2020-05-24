using Components;

namespace Ui.Scenes.Settings.Sliders
{
    public class ElementsSize : SliderBase
    {
        protected override float Value
        {
            get => Assets.Instance.Settings.ElementsSize;
            set => Assets.Instance.Settings.ElementsSize = value;
        }
    }
}