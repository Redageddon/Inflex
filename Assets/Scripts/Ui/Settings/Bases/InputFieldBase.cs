using UnityEngine;
using UnityEngine.UI;

namespace Ui.Settings.Bases
{
    public abstract class InputFieldBase : MonoBehaviour //SettingsBase
    {
        [SerializeField] private InputField inputField;

        protected abstract string Input { get; set; }

        protected virtual void OnInputChange(string input)
        {
            this.Input = input;
            ScreenResolution.Refresh();
        }

        private void Start()
        {
            this.inputField.onValueChanged.AddListener(this.OnInputChange);
            this.inputField.text = this.Input;
        }
    }
}