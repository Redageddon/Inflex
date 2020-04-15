using UnityEngine.UI;

public abstract class SliderBase : SettingsBase
{
    public Slider slider;
    protected abstract float Value { get; set; }
    
    private void Start()
    {
        slider.onValueChanged.AddListener(OnInputChange);
        slider.value = Value;
    }

    protected virtual void OnInputChange(float value)
    {
        Value = value;
    }
}