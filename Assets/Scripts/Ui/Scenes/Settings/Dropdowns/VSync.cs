using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class VSync : DropdownBase
{
    protected override int Index
    {
        get => Assets.Instance.Settings.VSyncIndex;
        set => Assets.Instance.Settings.VSyncIndex = value;
    }

    protected override void OnOptionChange(int index)
    {
        QualitySettings.vSyncCount = index;
        base.OnOptionChange(index);
    }

    protected override void FillDropdown() => this.dropdown.options.AddRange(new[] {"Off", "On", "Every Second V Blank"}.Select(option => new Dropdown.OptionData(option)));
}