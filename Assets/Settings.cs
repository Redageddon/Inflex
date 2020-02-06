using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    private SavedSettings settings;
    public static List<KeyCode> Keys;
    public static float Volume;

    private void Start()
    {
        settings = JsonLoader.LoadSettings();
        Keys = settings.Mapping;
        
    }

    public void SetVolume(float volume)
    {
        Volume = volume;
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
                break;
            case "KeyPreset2":
                Keys[1] = e.keyCode;
                break;
            case "KeyPreset3":
                Keys[2] = e.keyCode;
                break;
            case "KeyPreset4":
                Keys[3] = e.keyCode;
                break;
        }
        CurrentKey.GetComponentInChildren<Text>().text = e.keyCode.ToString();
        CurrentKey = null;
    }
    public void SetKeyCode(GameObject clicked)
    {
        CurrentKey = clicked;
    }
}
