using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SettingsTest : MonoBehaviour
{
    [SerializeField] private InputField skinInputField;
    [SerializeField] private InputField fpsInputField;
    [SerializeField] private Dropdown vSyncDropdown;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider elementsSizeSlider;
    [SerializeField] private Button saveButton;

    private void Start()
    {
        AddListeners();
        SetValues();
    }

    private void AddListeners()
    {
        skinInputField.onValueChanged.AddListener(OnSkinNameChange);
        fpsInputField.onValueChanged.AddListener(OnFpsChange);
        vSyncDropdown.onValueChanged.AddListener(OnVSyncChange);
        volumeSlider.onValueChanged.AddListener(OnVolumeChange);
        elementsSizeSlider.onValueChanged.AddListener(OnElementsSizeChange);
        saveButton.onClick.AddListener(OnSavePressed);
    }

    private void SetValues()
    {
        skinInputField.text = Assets.Instance.Settings.SkinName;
        fpsInputField.text = Assets.Instance.Settings.PreferredFps.ToString();
        vSyncDropdown.value = Assets.Instance.Settings.VSyncIndex;
        volumeSlider.value = Assets.Instance.Settings.Volume;
        elementsSizeSlider.value = Assets.Instance.Settings.ElementsSize;
        vSyncDropdown.RefreshShownValue();
    }

    private void OnSkinNameChange(string skinName)
    {
        Assets.Instance.Settings.SkinName = skinName;
    }
    
    private void OnResolutionChange(int index)
    {
        Assets.Instance.Settings.ResolutionIndex = index;
        SetScreenValues();
    }

    private void OnFpsChange(string value)
    {
        int.TryParse(value, out int preferredFps);
        Assets.Instance.Settings.PreferredFps = preferredFps;
        SetScreenValues();
    }

    private void SetScreenValues()
    {
        Screen.SetResolution(Screen.resolutions.ElementAt(Assets.Instance.Settings.ResolutionIndex).width,
            Screen.resolutions.ElementAt(Assets.Instance.Settings.ResolutionIndex).height,
            (FullScreenMode) Assets.Instance.Settings.FullscreenModeIndex, Assets.Instance.Settings.PreferredFps);
    }

    private void OnVSyncChange(int index)
    {
        QualitySettings.vSyncCount = index;
        Assets.Instance.Settings.VSyncIndex = index;
    }

    private void OnVolumeChange(float value)
    {
        Assets.Instance.Settings.Volume = value;
    }

    private void OnElementsSizeChange(float value)
    {
        Assets.Instance.Settings.ElementsSize = value;
    }

    private void OnSavePressed() => SaveSettings();

    private void SaveSettings() => JsonLoader.Save(Assets.Instance.Settings, GenericPaths.SettingsPath + "Test");
}