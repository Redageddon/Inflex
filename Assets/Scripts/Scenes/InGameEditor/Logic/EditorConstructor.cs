using System.IO;
using Audio;
using SceneLessLogic.Beatmaps;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.InGameEditor.Logic
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