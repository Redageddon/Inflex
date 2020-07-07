using Logic;

namespace Ui.Settings.InputFields
{
    public class SkinName : InputFieldBase
    {
        protected override string Input
        {
            get => Assets.Instance.Settings.SkinName;
            set => Assets.Instance.Settings.SkinName = value;
        }
    }
}