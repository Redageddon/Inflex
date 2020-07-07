using System.IO;
using Logic.InGameEditor;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.InGameEditor.Buttons
{
    public class Song : MouseNavigationControl
    {
        [SerializeField] private Text text;
        protected override void LeftClick()
        {
            string songPath = EditorUtility.OpenFilePanel(null, null, "mp3,ogg,wav");

            if (string.IsNullOrEmpty(songPath))
            {
                return;
            }

            this.text.text = Path.GetFileName(songPath);
            EditorInitializer.BeatMap.SongFile = songPath;
        }
    }
}