using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public abstract class DropdownBase : MonoBehaviour
{
    public Dropdown dropdown;
    private void Start()
    {
        dropdown.onValueChanged.AddListener(OnOptionChange);
        dropdown.ClearOptions();
        FillDropdown();
        dropdown.value = GetValue();
        dropdown.RefreshShownValue();
    }

    protected abstract void OnOptionChange(int index);

    protected abstract int GetValue();

    protected abstract void FillDropdown();

    protected static void SetScreenValues()
    {
        Screen.SetResolution(Screen.resolutions.ElementAt(Assets.Instance.Settings.ResolutionIndex).width,
            Screen.resolutions.ElementAt(Assets.Instance.Settings.ResolutionIndex).height,
            (FullScreenMode) Assets.Instance.Settings.FullscreenModeIndex, Assets.Instance.Settings.PreferredFps);
    }
}