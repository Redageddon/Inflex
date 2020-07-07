using System.IO;
using Logic.InGameEditor;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.InGameEditor.Buttons
{
    public class Background : MouseNavigationControl
    {
        [SerializeField] private Text text;
        protected override void LeftClick()
        {
            string bgPath = EditorUtility.OpenFilePanel(null, null, "png,jpg");

            if (string.IsNullOrEmpty(bgPath))
            {
                return;
            }

            this.text.text = Path.GetFileName(bgPath);
            EditorInitializer.BeatMap.Background = bgPath;
        }
    }
}