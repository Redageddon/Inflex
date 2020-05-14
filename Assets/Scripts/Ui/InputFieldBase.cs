using Ui.Scenes.Settings;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public abstract class InputFieldBase : SettingsBase
    {
        [SerializeField] private InputField inputField;

        protected abstract string Input { get; set; }

        protected virtual void OnInputChange(string input)
        {
            this.Input = input;
            this.SetScreenValues();
        }

        private void Start()
        {
            this.inputField.onValueChanged.AddListener(this.OnInputChange);
            this.inputField.text = this.Input;
        }
    }
}