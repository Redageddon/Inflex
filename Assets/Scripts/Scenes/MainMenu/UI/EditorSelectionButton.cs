using Packages.SFB;
using SceneLessLogic;
using Scenes.InGameEditor.Logic;
using Ui;

namespace Scenes.MainMenu.UI
{
    public class EditorSelectionButton : NavigationButton
    {
        protected override void LeftClick()
        {
            var path = StandaloneFileBrowser.OpenFilePanel("Open File", GenericPaths.BeatMapsPath, "rron", false);

            if (path.Length == 1 && !string.IsNullOrEmpty(path[0]))
            {
                EditorInitializer.Path              = path[0];
                EditorInitializer.IsExistingBeatMap = true;
                base.LeftClick();
            }
        }
    }
}