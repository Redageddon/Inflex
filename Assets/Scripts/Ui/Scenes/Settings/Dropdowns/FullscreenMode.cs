using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FullscreenMode : DropdownBase
{
    protected override int Index
    {
        get => Assets.Instance.Settings.FullscreenModeIndex;
        set => Assets.Instance.Settings.FullscreenModeIndex = value;
    }

    protected override void FillDropdown() => this.dropdown.options.AddRange(Enum.GetNames(typeof(FullScreenMode)).Select(mode => new Dropdown.OptionData($"{mode}")));
}