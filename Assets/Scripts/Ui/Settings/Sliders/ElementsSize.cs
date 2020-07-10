using Logic;
using Ui.Settings.Bases;

namespace Ui.Settings.Sliders
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