using System.Collections.Generic;

public class SavedSettings
{
    public SavedSettings() { }

    public SavedSettings(string @default)
    {
        if (@default.Equals("Default"))
        {
            SkinName = @default;
            PreferredFps = 60;
            ResolutionIndex = default;
            FullscreenModeIndex = default;
            VSyncIndex = default;
            Volume = 100;
            ElementsSize = 100;
            Keys = new List<int>{119, 97, 115 ,100};
        }
    }

    public string SkinName { get; set; }
    public int PreferredFps { get; set; }
    public int ResolutionIndex { get; set; }
    public int FullscreenModeIndex { get; set; }
    public int VSyncIndex { get; set; }
    public float Volume { get; set; }
    public float ElementsSize { get; set; }
    public List<int> Keys { get; set; }

    public override string ToString() => $"{nameof(SkinName)}: {SkinName}, {nameof(FullscreenModeIndex)}: {FullscreenModeIndex}, {nameof(ResolutionIndex)}: {ResolutionIndex}, {nameof(PreferredFps)}: {PreferredFps}, {nameof(VSyncIndex)}: {VSyncIndex}, {nameof(Volume)}: {Volume}, {nameof(ElementsSize)}: {ElementsSize}, {nameof(Keys)}: {Keys}";
}