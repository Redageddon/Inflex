using Logic.InGameEditor;
using Packages.SFB;

namespace Ui.MainMenu
{
    public class EditorSelectionButton : NavigationButton
    {
        protected override void LeftClick()
        {
            string[] path = StandaloneFileBrowser.OpenFilePanel("Open File", GenericPaths.BeatMapsPath, "rron", false);
            
            if (path.Length == 1 && !string.IsNullOrEmpty(path[0]))
            {
                EditorInitializer.Path              = path[0];
                EditorInitializer.IsExistingBeatMap = true;
                base.LeftClick();
            }
        }
    }
}