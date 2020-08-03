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

        public void Fill(BeatMapMeta beatMapMeta)
        {
            string folderPath = Path.GetDirectoryName(beatMapMeta.Path);
            AudioPlayer.Instance.LoadAudio(Path.Combine(folderPath, beatMapMeta.SongFile));
            this.slider.maxValue = AudioPlayer.Instance.ClipLengthInSeconds;
        }
    }
}