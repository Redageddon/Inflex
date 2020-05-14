using Components.InGameEditor;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ui.Scenes.MainMenu
{
    public class EditorSelectionButton : ButtonBase
    {
        [SerializeField] private bool isNewBeatMap;
        [SerializeField] private string navigation;

        protected override void Left()
        {
            string path = EditorUtility.OpenFilePanel(null, null, "rron");

            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            if (!this.isNewBeatMap)
            {
                EditorConstructor.Path = path;
            }

            EditorConstructor.IsNewBeatMap = this.isNewBeatMap;
            SceneManager.LoadScene(this.navigation, LoadSceneMode.Single);
        }
    }
}