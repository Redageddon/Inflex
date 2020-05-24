using Components;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Scenes.Settings.Buttons
{
    public class KeySetter : ButtonBase
    {
        [SerializeField] private int keyIndex;
        [SerializeField] private Text text;
        private bool waitingForInput;

        protected override void Left() => this.waitingForInput = true;

        private void Start() => this.SetText();

        private void OnGUI()
        {
            if (!this.waitingForInput || !Event.current.isKey)
            {
                return;
            }

            Assets.Instance.Settings.Keys[this.keyIndex] = (int) Event.current.keyCode;
            this.waitingForInput = false;
            this.SetText();
        }

        private void SetText() => this.text.text = $" Input{this.keyIndex}: {(KeyCode) Assets.Instance.Settings.Keys[this.keyIndex]}";
    }
}