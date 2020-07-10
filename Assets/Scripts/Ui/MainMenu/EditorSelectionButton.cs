using Logic.InGameEditor;
using UnityEditor;

namespace Ui.MainMenu
{
    public class EditorSelectionButton : NavigationButton
    {
        protected override void LeftClick()
        {
            string path;
            #if UNITY_EDITOR
            path = EditorUtility.OpenFilePanel("Beatmap", GenericPaths.BeatMapsPath, "rron");
            #else
            path = OtherUtility.OpenFilePanel("Beatmap", GenericPaths.BeatMapsPath, "rron");
            #endif
            
            if (!string.IsNullOrEmpty(path))
            {
                EditorInitializer.Path = path;
                EditorInitializer.IsExistingBeatMap = true;
                base.LeftClick();
            }
        }
    }
}