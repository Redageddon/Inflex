using System;
using Audio;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.InGameEditor
{
    public class TimeCatcher : MonoBehaviour
    {
        [SerializeField] private Text text;

        private void Update()
        {
            this.text.text = $"{AudioPlayer.Instance.AudioTime}/{AudioPlayer.Instance.ClipLengthInSeconds}";
        }
    }
}