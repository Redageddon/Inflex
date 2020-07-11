using System;
using System.Linq;
using Logic;
using Ui.Settings.Bases;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Settings.Dropdowns
{
    public class VSync : DropdownBase
    {
        protected override int Index
        {
            get => (int)Assets.Instance.Settings.VSyncIndex;
            set => Assets.Instance.Settings.VSyncIndex = (VSyncMode)value;
        }

        protected override void FillDropdown() => this.Dropdown.options.AddRange(Enum.GetNames(typeof(VSyncMode)).Select(option => new Dropdown.OptionData(option)));

        protected override void OnOptionChange(int index)
        {
            QualitySettings.vSyncCount = index;
            base.OnOptionChange(index);
        }
    }
}