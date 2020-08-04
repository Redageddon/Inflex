using Inflex.Rron;
using SceneLessLogic;
using Ui;

namespace Scenes.Settings.UI.Buttons
{
    public class SaveButton : MouseNavigationControl
    {
        protected override void LeftClick() => RronConvert.SerializeObjectToFile(Assets.Instance.Settings, GenericPaths.SettingsPath);
    }
}