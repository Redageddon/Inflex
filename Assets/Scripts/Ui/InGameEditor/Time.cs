using System;
using Components.Audio;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Scenes.InGameEditor
{
    public class Time : MonoBehaviour
    {
        [SerializeField] private Text text;
        private void Update()
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(AudioPlayer.Instance.GetAudioTime);
            this.text.text = $"{timeSpan.Minutes}:{timeSpan.Seconds}:{timeSpan.Milliseconds}";
        }
    }
}