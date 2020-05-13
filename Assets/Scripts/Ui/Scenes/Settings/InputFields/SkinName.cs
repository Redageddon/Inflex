using Components;

namespace Ui.Scenes.Settings.InputFields
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