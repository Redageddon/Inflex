using Components;
using Inflex.Rron;

namespace Ui.Scenes.Settings.Buttons
{
    public class SaveButton : ButtonBase
    {
        protected override void Left() => RronConvert.SerializeObjectToFile(Assets.Instance.Settings, GenericPaths.SettingsPath);
    }
}