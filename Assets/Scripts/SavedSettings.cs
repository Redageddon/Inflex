using System.Collections.Generic;
using UnityEngine;

public class SavedSettings
{ 
    public float Volume { get; set; }
    public List<KeyCode> Keys { get; set; }
    public Resolution Resolution { get; set; }
    public FullScreenMode ScreenMode { get; set; }
    public float ElementsSize { get; set; }
    public string SkinName { get; set; }
}