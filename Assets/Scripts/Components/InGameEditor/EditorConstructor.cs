using System.IO;
using BeatMaps;
using Components.Audio;
using UnityEngine;
using UnityEngine.UI;

namespace Components.InGameEditor
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