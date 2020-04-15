using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FullscreenMode : DropdownBase
{
    protected override void OnOptionChange(int index)
    {
        Assets.Instance.Settings.FullscreenModeIndex = index;
        SetScreenValues();
    }

    protected override int GetValue() => Assets.Instance.Settings.FullscreenModeIndex;

    protected override void FillDropdown() => dropdown.options.AddRange(Enum.GetNames(typeof(FullScreenMode)).Select(mode => new Dropdown.OptionData($"{mode}")));
}