using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Resolution : DropdownBase
{
    protected override void OnOptionChange(int index)
    {
        Assets.Instance.Settings.ResolutionIndex = index;
        SetScreenValues();
    }

    protected override int GetValue() => Assets.Instance.Settings.ResolutionIndex;

    protected override void FillDropdown() => dropdown.options.AddRange(Screen.resolutions.Select(resolution => new Dropdown.OptionData($"{resolution.width} X {resolution.height}")));
}