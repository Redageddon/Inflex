using System.Collections.Generic;
using UnityEngine;

public class SavedSettings
{
    public string SkinName { get; set; }
    public int PreferredFps { get; set; }
    public int ResolutionIndex { get; set; }
    public int FullscreenModeIndex { get; set; }
    public int VSyncIndex { get; set; }
    public float Volume { get; set; }
    public float ElementsSize { get; set; }
    public List<KeyCode> Keys { get; set; }

    public override string ToString() => $"{nameof(SkinName)}: {SkinName}, {nameof(FullscreenModeIndex)}: {FullscreenModeIndex}, {nameof(ResolutionIndex)}: {ResolutionIndex}, {nameof(PreferredFps)}: {PreferredFps}, {nameof(VSyncIndex)}: {VSyncIndex}, {nameof(Volume)}: {Volume}, {nameof(ElementsSize)}: {ElementsSize}, {nameof(Keys)}: {Keys}";
}