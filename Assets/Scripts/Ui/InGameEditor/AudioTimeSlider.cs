using Audio;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.InGameEditor
{
    public class AudioTimeSlider : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        private                  bool   mouseDown;
        private                  bool   wasPlaying;

        private void Update() => this.slider.value = AudioPlayer.Instance.AudioTime;

        private void Start() => this.slider.onValueChanged.AddListener(this.OnInputChange);

        private void OnMouseDown()
        {
            this.mouseDown  = true;
            this.wasPlaying = !AudioPlayer.Instance.AudioPaused;
        }

        private void OnMouseUp()
        {
            this.mouseDown                   = false;
            AudioPlayer.Instance.AudioPaused = !this.wasPlaying;
        }

        private void OnInputChange(float value)
        {
            if (this.mouseDown)
            {
                AudioPlayer.Instance.AudioPaused = true;
                AudioPlayer.Instance.AudioTime   = value;
            }
        }
    }
}