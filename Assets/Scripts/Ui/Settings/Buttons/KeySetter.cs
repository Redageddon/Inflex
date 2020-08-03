using Logic;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Settings.Buttons
{
    public class KeySetter : MouseNavigationControl
    {
        public                   int  keyIndex;
        [SerializeField] private Text text;
        private                  bool waitingForInput;

        protected override void LeftClick() => this.waitingForInput = true;

        private void Start() => this.SetText();

        private void OnGUI()
        {
            if (this.waitingForInput && Event.current.isKey)
            {
                Assets.Instance.Settings.Keys[this.keyIndex] = Event.current.keyCode;
                this.waitingForInput                         = false;
                this.SetText();
            }
        }

        private void SetText() => this.text.text = $" Input{this.keyIndex}: {Assets.Instance.Settings.Keys[this.keyIndex]}";
    }
}