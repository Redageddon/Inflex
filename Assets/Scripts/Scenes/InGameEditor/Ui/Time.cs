using System;
using Audio;
using Ui;

namespace Scenes.InGameEditor.Ui
{
    public class Time : WrittenElement
    {
        private void Update()
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(AudioPlayer.Instance.AudioTime);
            this.Text.text = $"{timeSpan.Minutes}.{timeSpan.Seconds}.{timeSpan.Milliseconds}";
        }
    }
}