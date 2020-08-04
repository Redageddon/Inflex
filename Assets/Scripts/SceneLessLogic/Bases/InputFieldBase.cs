using Scenes.Settings.Logic;
using UnityEngine;
using UnityEngine.UI;

namespace SceneLessLogic.Bases
{
    public abstract class InputFieldBase : MonoBehaviour
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