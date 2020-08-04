using System;
using System.Linq;
using SceneLessLogic;
using SceneLessLogic.Bases;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Settings.Dropdowns
{
    public class FullscreenMode : DropdownBase
    {
        protected override int Index
        {
            get => (int)Assets.Instance.Settings.FullscreenMode;
            set => Assets.Instance.Settings.FullscreenMode = (FullScreenMode)value;
        }

        protected override void FillDropdown() =>
            this.Dropdown.options.AddRange(Enum.GetNames(typeof(FullScreenMode)).Select(mode => new Dropdown.OptionData($"{mode}")));
    }
}