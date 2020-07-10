using Audio;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.InGameEditor
{
    public class AudioTimeSlider : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        private bool mouseDown;
        private bool wasPlaying;

        private void Update() => this.slider.value = AudioPlayer.Instance.AudioTime;

        private void Start() => this.slider.onValueChanged.AddListener(this.OnInputChange);

        private void OnMouseDown()
        {
            this.mouseDown = true;
            this.wasPlaying = AudioPlayer.Instance.audioSource.isPlaying;
        }

        private void OnMouseUp()
        {
            this.mouseDown = false;
            AudioPlayer.Instance.SetAudioPaused(!this.wasPlaying);
        }

        private void OnInputChange(float value)
        {
            if (this.mouseDown)
            {
                AudioPlayer.Instance.SetAudioPaused(true);
                AudioPlayer.Instance.AudioTime = value;
            }
        }
    }
}