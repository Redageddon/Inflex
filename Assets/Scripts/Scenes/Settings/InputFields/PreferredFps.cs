using SceneLessLogic;
using SceneLessLogic.Bases;

namespace Scenes.Settings.InputFields
{
    public class PreferredFps : InputFieldBase
    {
        protected override string Input
        {
            get => Assets.Instance.Settings.Resolution.RefreshRate.ToString();
            set
            {
                int.TryParse(value, out int val);
                Assets.Instance.Settings.Resolution.RefreshRate = val;
            }
        }
    }
}