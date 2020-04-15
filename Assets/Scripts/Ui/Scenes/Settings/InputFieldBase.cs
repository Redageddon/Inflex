using UnityEngine.UI;

public abstract class InputFieldBase : SettingsBase
{
    public InputField inputField;
    protected abstract string Input { get; set; }
    
    private void Start()
    {
        inputField.onValueChanged.AddListener(OnInputChange);
        inputField.text = Input;
    }

    protected virtual void OnInputChange(string input)
    {
        Input = input;
        SetScreenValues();
    }
}