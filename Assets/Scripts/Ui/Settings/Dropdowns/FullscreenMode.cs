using System;
using System.Linq;
using Logic;
using Ui.Settings.Bases;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Settings.Dropdowns
{
    public class FullscreenMode : DropdownBase
    {
        protected override int Index
        {
            get => Assets.Instance.Settings.FullscreenModeIndex;
            set => Assets.Instance.Settings.FullscreenModeIndex = value;
        }

        protected override void FillDropdown() =>
            this.Dropdown.options.AddRange(Enum.GetNames(typeof(FullScreenMode)).Select(mode => new Dropdown.OptionData($"{mode}")));
    }
}