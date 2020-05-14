using System.IO;
using Components.InGameEditor;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Scenes.InGameEditor.Buttons
{
    public class Background : ButtonBase
    {
        [SerializeField] private Text text;
        protected override void Left()
        {
            string bgPath = EditorUtility.OpenFilePanel(null, null, "png,jpg");

            if (string.IsNullOrEmpty(bgPath))
            {
                return;
            }

            this.text.text = Path.GetFileName(bgPath);
            EditorConstructor.BeatMap.Background = bgPath;
        }
    }
}