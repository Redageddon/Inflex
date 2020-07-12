using System.IO;
using Logic.InGameEditor;
using Packages.SFB;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.InGameEditor.Buttons
{
    public class Song : MouseNavigationControl
    {
        [SerializeField] private Text text;
        protected override void LeftClick()
        {
            string[] path = StandaloneFileBrowser.OpenFilePanel("Open File", "", "mp3,ogg,wav", false);

            if (path.Length == 1 && !string.IsNullOrEmpty(path[0]))
            {
                this.text.text                     = Path.GetFileName(path[0]);
                EditorInitializer.BeatMap.SongFile = path[0];
            }
        }
    }
}