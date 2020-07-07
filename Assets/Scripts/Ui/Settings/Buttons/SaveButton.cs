using Inflex.Rron;
using Logic;

namespace Ui.Settings.Buttons
{
    public class SaveButton : MouseNavigationControl
    {
        protected override void LeftClick() => RronConvert.SerializeObjectToFile(Assets.Instance.Settings, GenericPaths.SettingsPath);
    }
}