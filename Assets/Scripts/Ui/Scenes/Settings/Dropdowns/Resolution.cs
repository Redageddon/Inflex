using System.Linq;
using UnityEngine.UI;

public class Resolution : DropdownBase
{
    protected override int Index
    {
        get => Assets.Instance.Settings.ResolutionIndex;
        set => Assets.Instance.Settings.ResolutionIndex = value;
    }

    protected override void FillDropdown()
    {
        dropdown.options.AddRange(Resolutions.Select(resolution => new Dropdown.OptionData($"{resolution.width} X {resolution.height}")).Distinct());
    }
}