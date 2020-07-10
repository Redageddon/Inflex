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
            string bgPath;
            #if UNITY_EDITOR
            bgPath = EditorUtility.OpenFilePanel(null, null, "png,jpg");
            #else
            bgPath = OtherUtility.OpenFilePanel(null, null, "png,jpg");
            #endif
            

            if (string.IsNullOrEmpty(bgPath))
            {
                return;
            }

            this.text.text = Path.GetFileName(bgPath);
            EditorInitializer.BeatMap.Background = bgPath;
        }
    }
}