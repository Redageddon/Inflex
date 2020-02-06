using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Text[] keyPresets;
    [SerializeField] private Slider volume;
    public static float Volume;
    private SavedSettings _settings;
    public static List<KeyCode> Keys;

    private void Start()
    {
        _settings = JsonLoader.LoadSettings();
        Keys = _settings.Mapping;

        for (int i = 0; i < 4; i++)
        {
            keyPresets[i].text = Keys[i].ToString();
        }

        volume.value = _settings.Volume;
        Volume = volume.value;
    }

    

    private GameObject CurrentKey;

    private void OnGUI()
    {
        if (CurrentKey == null) return;
        Event e = Event.current;
        if (!e.isKey) return;
        switch (CurrentKey.name)
        {
            case "KeyPreset1":
                Keys[0] = e.keyCode;
                _settings.Mapping[0] = e.keyCode;
                break;
            case "KeyPreset2":
                Keys[1] = e.keyCode;
                _settings.Mapping[1] = e.keyCode;
                break;
            case "KeyPreset3":
                Keys[2] = e.keyCode;
                _settings.Mapping[2] = e.keyCode;
                break;
            case "KeyPreset4":
                Keys[3] = e.keyCode;
                _settings.Mapping[3] = e.keyCode;
                break;
        }

        CurrentKey.GetComponentInChildren<Text>().text = e.keyCode.ToString();
        CurrentKey = null;
    }

    public void SetKeyCode(GameObject clicked)
    {
        CurrentKey = clicked;
    }
    
    public void SaveSettings()
    {
        JsonLoader.SaveSettings(_settings);
    }

    public void SetVolume(float value)
    {
        volume.value = value;
        _settings.Volume = value;
    }
}