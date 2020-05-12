using UnityEngine;
using UnityEngine.UI;

public abstract class InputFieldBase : SettingsBase
{
    [SerializeField] public InputField inputField;

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