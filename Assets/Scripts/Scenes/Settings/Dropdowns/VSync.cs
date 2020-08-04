using System;
using System.Linq;
using SceneLessLogic;
using SceneLessLogic.Bases;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Settings.Dropdowns
{
    public class VSync : DropdownBase
    {
        protected override int Index
        {
            get => (int)Assets.Instance.Settings.VSyncIndex;
            set => Assets.Instance.Settings.VSyncIndex = (VSyncMode)value;
        }

        protected override void FillDropdown() =>
            this.Dropdown.options.AddRange(Enum.GetNames(typeof(VSyncMode)).Select(option => new Dropdown.OptionData(option)));

        protected override void OnOptionChange(int index)
        {
            QualitySettings.vSyncCount = index;
            base.OnOptionChange(index);
        }
    }
}