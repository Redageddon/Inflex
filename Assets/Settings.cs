using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Text[] keyPresets;
    [SerializeField] private Slider volume;
    [SerializeField] private Dropdown dropDownRes;
    [SerializeField] private Dropdown dropDownScreenMode;
    [SerializeField] private InputField fps;
    public static SavedSettings GlobalSettings;
    private Resolution _resolution;
    private GameObject _currentKey;
    private List<KeyCode> _keys;
    private bool _screenRes;


    private void Start()
    {
        GlobalSettings = JsonLoader.LoadSettings();
        _keys = GlobalSettings.Keys;
        fps.text = GlobalSettings.Resolution.refreshRate.ToString();
        volume.value = GlobalSettings.Volume;
        _resolution = GlobalSettings.Resolution;
        
        for (int i = 0; i < 4; i++)
        {
            keyPresets[i].text = _keys[i].ToString();
        }
        
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = Screen.resolutions[i].width + " x " + Screen.resolutions[i].height;
            dropDownRes.options.Add(option);
            dropDownRes.value = i;
        }

        for (int i = 0; i < Enum.GetValues(typeof(FullScreenMode)).Length; i++)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = Enum.GetValues(typeof(FullScreenMode)).GetValue(i).ToString();
            dropDownScreenMode.options.Add(option);
            dropDownScreenMode.value = i;
        }
    }

    private void OnGUI()
    {
        if (_currentKey == null) return;
        Event e = Event.current;
        if (!e.isKey) return;
        switch (_currentKey.name)
        {
            case "KeyPreset1":
                _keys[0] = e.keyCode;
                GlobalSettings.Keys[0] = e.keyCode;
                break;
            case "KeyPreset2":
                _keys[1] = e.keyCode;
                GlobalSettings.Keys[1] = e.keyCode;
                break;
            case "KeyPreset3":
                _keys[2] = e.keyCode;
                GlobalSettings.Keys[2] = e.keyCode;
                break;
            case "KeyPreset4":
                _keys[3] = e.keyCode;
                GlobalSettings.Keys[3] = e.keyCode;
                break;
        }

        _currentKey.GetComponentInChildren<Text>().text = e.keyCode.ToString();
        _currentKey = null;
    }

    public void SetKeyCode(GameObject clicked)
    {
        _currentKey = clicked;
    }

    public void SetVolume(float value)
    {
        volume.value = value;
        GlobalSettings.Volume = value;
    }

    public void SetResolution()
    {
        _resolution.height = Screen.resolutions[dropDownRes.value].height;
        _resolution.width = Screen.resolutions[dropDownRes.value].width;
    }

    public void SetFps()
    {
        _resolution.refreshRate = int.Parse(fps.text);
    }

    public void SetScreenMode()
    {
        GlobalSettings.ScreenMode = (FullScreenMode)dropDownScreenMode.value;
    }
    
    public void SaveSettings()
    {
        JsonLoader.SaveSettings(GlobalSettings);
    }
}