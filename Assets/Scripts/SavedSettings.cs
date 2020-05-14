using System;
using System.Collections.Generic;

public class SavedSettings
{
    public SavedSettings()
    {
    }

    public SavedSettings(string name)
    {
        if (name != null && name.Equals("Default", StringComparison.OrdinalIgnoreCase))
        {
            this.SkinName = name;
            this.PreferredFps = 60;
            this.ResolutionIndex = default;
            this.FullscreenModeIndex = default;
            this.VSyncIndex = default;
            this.Volume = 100;
            this.ElementsSize = 100;
            this.Keys = new List<int> {119, 97, 115, 100};
        }
    }

    public string SkinName { get; set; }

    public int PreferredFps { get; set; }

    public int ResolutionIndex { get; set; }

    public int FullscreenModeIndex { get; set; }

    public int VSyncIndex { get; set; }

    public float Volume { get; set; }

    public float ElementsSize { get; set; }

    public List<int> Keys { get; set; } = new List<int>();

    public override string ToString() =>
        $"{nameof(this.SkinName)}: {this.SkinName}, {nameof(this.FullscreenModeIndex)}: {this.FullscreenModeIndex}, {nameof(this.ResolutionIndex)}: {this.ResolutionIndex}, {nameof(this.PreferredFps)}: {this.PreferredFps}, {nameof(this.VSyncIndex)}: {this.VSyncIndex}, {nameof(this.Volume)}: {this.Volume}, {nameof(this.ElementsSize)}: {this.ElementsSize}, {nameof(this.Keys)}: {this.Keys}";
}