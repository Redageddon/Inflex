using Logic.InGameEditor;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ui.Scenes.MainMenu
{
    public class EditorSelectionButton : ButtonBase
    {
        [SerializeField] private string navigation;

        protected override void Left()
        {
            string path = EditorUtility.OpenFilePanel(null, null, "rron");

            if (!string.IsNullOrEmpty(path))
            {
                EditorInitializer.Path = path;
                EditorInitializer.IsExistingBeatMap = true;
                SceneManager.LoadScene(this.navigation, LoadSceneMode.Single);
            }
        }
    }
}