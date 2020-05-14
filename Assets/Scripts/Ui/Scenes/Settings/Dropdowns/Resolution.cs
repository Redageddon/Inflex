using System.Linq;
using Components;
using UnityEngine.UI;

namespace Ui.Scenes.Settings.Dropdowns
{
    public class Resolution : DropdownBase
    {
        protected override int Index
        {
            get => Assets.Instance.Settings.ResolutionIndex;
            set => Assets.Instance.Settings.ResolutionIndex = value;
        }

        protected override void FillDropdown() =>
            this.Dropdown.options.AddRange(this.Resolutions.Select(resolution =>
                                                                       new Dropdown.OptionData($"{resolution.width} X {resolution.height}"))
                                               .Distinct());
    }
}