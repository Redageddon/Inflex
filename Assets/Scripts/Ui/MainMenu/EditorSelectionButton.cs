using Logic.InGameEditor;
using UnityEditor;

namespace Ui.MainMenu
{
    public class EditorSelectionButton : NavigationButton
    {
        protected override void LeftClick()
        {
            string path = EditorUtility.OpenFilePanel("Beatmap", GenericPaths.BeatMapsPath, "rron");

            if (!string.IsNullOrEmpty(path))
            {
                EditorInitializer.Path = path;
                EditorInitializer.IsExistingBeatMap = true;
                base.LeftClick();
            }
        }
    }
}