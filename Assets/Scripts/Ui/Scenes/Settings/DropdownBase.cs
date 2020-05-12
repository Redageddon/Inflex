using UnityEngine.UI;

public abstract class DropdownBase : SettingsBase
{
    public Dropdown dropdown;

    protected abstract int Index { get; set; }

    protected abstract void FillDropdown();

    protected virtual void OnOptionChange(int index)
    {
        this.Index = index;
        this.SetScreenValues();
    }

    private void Start()
    {
        this.dropdown.onValueChanged.AddListener(this.OnOptionChange);
        this.dropdown.ClearOptions();
        this.FillDropdown();
        if (this.Index == 0)
        {
            this.OnOptionChange(0);
        }

        this.dropdown.value = this.Index;
        this.dropdown.RefreshShownValue();
    }
}