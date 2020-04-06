using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Text[] keyPresets;
    [SerializeField] private Slider volume;
    [SerializeField] private Slider centerSize;
    [SerializeField] private Dropdown dropDownRes;
    [SerializeField] private Dropdown dropDownScreenMode;
    [SerializeField] private InputField fps;
    private Resolution _resolution;
    private SavedSettings _savedSettings;
    private GameObject _currentKey;
    private List<KeyCode> _keys;
    private bool _screenRes;

    private void Start()
    {
        SetVariables();
        SetLoadedKeys();
        AddScreenResolutions();
        AddScreenModes();
    }

    private void OnGUI()
    {
        var e = Event.current;
        if (!e.isKey || _currentKey == null) return;
        var macroPressed = int.Parse(_currentKey.name);
        
        _keys[macroPressed] = e.keyCode;
        _savedSettings.Keys[macroPressed] = e.keyCode;
        _currentKey.GetComponentInChildren<Text>().text = e.keyCode.ToString();
        
        _currentKey = null;
    }

    private void SetLoadedKeys()
    {
        for (var i = 0; i < 4; i++)
        {
            keyPresets[i].text = _keys[i].ToString();
        }
    }

    private void SetVariables()
    {
        _savedSettings = Assets.Instance.SavedSettings;
        _keys = _savedSettings.Keys;
        fps.text = _savedSettings.Resolution.refreshRate.ToString();
        volume.value = _savedSettings.Volume;
        centerSize.value = _savedSettings.ElementsSize;
        _resolution = _savedSettings.Resolution;
    }

    private void AddScreenResolutions()
    {
        for (var i = 0; i < Screen.resolutions.Length; i++)
        {
            var option = new Dropdown.OptionData {text = Screen.resolutions[i].width + " x " + Screen.resolutions[i].height};
            if (Screen.resolutions[i].refreshRate == 60 || Screen.resolutions[i].refreshRate == 75)
            {
                dropDownRes.options.Add(option);
            }
            if (_savedSettings.Resolution.height == Screen.resolutions[i].height && _savedSettings.Resolution.width == Screen.resolutions[i].width)
            {
                dropDownRes.value = i;
            }
        }
    }

    private void AddScreenModes()
    {
        for (var i = 0; i < Enum.GetValues(typeof(FullScreenMode)).Length; i++)
        {
            var option = new Dropdown.OptionData {text = Enum.GetValues(typeof(FullScreenMode)).GetValue(i).ToString()};
            dropDownScreenMode.options.Add(option);
            if ((FullScreenMode) i == _savedSettings.ScreenMode)
            {
                dropDownScreenMode.value = i;
            }
        }
    }

    public void SetKeyCode(GameObject clicked)
    {
        _currentKey = clicked;
    }

    public void SetVolume(float value)
    {
        volume.value = value;
        _savedSettings.Volume = value;
    }
    public void SetCenterSize(float value)
    {
        centerSize.value = value;
        _savedSettings.ElementsSize = value;
    }

    public void SetResolution()
    {
        _resolution.height = Screen.resolutions[dropDownRes.value].height;
        _resolution.width = Screen.resolutions[dropDownRes.value].width;
        _savedSettings.Resolution = _resolution;
        UpdateResolution();
    }

    public void SetFps()
    {
        _resolution.refreshRate = int.Parse(fps.text);
        _savedSettings.Resolution = _resolution;
        UpdateResolution();
    }

    public void SetScreenMode()
    {
        _savedSettings.ScreenMode = (FullScreenMode) dropDownScreenMode.value;
        UpdateResolution();
    }

    private void UpdateResolution()
    {
        Screen.SetResolution(_savedSettings.Resolution.width,_savedSettings.Resolution.height, _savedSettings.ScreenMode, _savedSettings.Resolution.refreshRate);
    }

    public void SaveSettings()
    {
        Assets.Instance.SavedSettings = _savedSettings;
        SavedSettingsLoader.Instance.Save(GenericPaths.SettingsPath);
    }
}