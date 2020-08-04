using System.IO;
using Packages.SFB;
using Scenes.InGameEditor.Logic;
using Ui;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.InGameEditor.Ui.Buttons
{
    public class Song : MouseNavigationControl
    {
        [SerializeField] private Text text;

        protected override void LeftClick()
        {
            var path = StandaloneFileBrowser.OpenFilePanel("Open File", "", "mp3,ogg,wav", false);

            if (path.Length == 1 && !string.IsNullOrEmpty(path[0]))
            {
                this.text.text                         = Path.GetFileName(path[0]);
                EditorInitializer.BeatMapMeta.SongFile = path[0];
            }
        }
    }
}