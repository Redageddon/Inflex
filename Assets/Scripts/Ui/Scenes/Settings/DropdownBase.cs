using UnityEngine.UI;

public abstract class DropdownBase : SettingsBase
{
    public Dropdown dropdown;
    protected abstract int Index { get; set; }

    private void Start()
    {
        dropdown.onValueChanged.AddListener(OnOptionChange);
        dropdown.ClearOptions();
        FillDropdown();
        if (Index == 0) OnOptionChange(0);
        dropdown.value = Index;
        dropdown.RefreshShownValue();
    }
    
    protected abstract void FillDropdown();

    protected virtual void OnOptionChange(int index)
    {
        Index = index;
        SetScreenValues();
    }
}