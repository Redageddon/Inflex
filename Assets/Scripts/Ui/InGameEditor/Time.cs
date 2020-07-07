using System;
using Audio;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.InGameEditor
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