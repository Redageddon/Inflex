using System.IO;
using Audio;
using Beatmaps;
using UnityEngine;
using UnityEngine.UI;

namespace Logic.InGameEditor
{
    public class EditorConstructor : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        public void Fill(BeatMap beatMap)
        {
            string folderPath = Path.GetDirectoryName(beatMap.Path);
            AudioPlayer.Instance.LoadAudio(Path.Combine(folderPath, beatMap.SongFile));
            this.slider.maxValue = AudioPlayer.Instance.GetClipLength;
        }
    }
}