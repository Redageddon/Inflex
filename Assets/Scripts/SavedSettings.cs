using System;
using System.Collections.Generic;
using UnityEngine;

public class SavedSettings
{
    public SavedSettings()
    {
    }

    public SavedSettings(string name)
    {
        if (!string.IsNullOrEmpty(name) && name.Equals("Default", StringComparison.OrdinalIgnoreCase))
        {
            this.SkinName       = name;
            this.FullscreenMode = default;
            this.VSyncIndex     = default;
            this.Volume         = 100;
            this.ElementsSize   = 100;
            this.Resolution     = new Resolution(1080, 1920, 60);
            this.Keys           = new List<KeyCode> {KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D};
        }
    }

    public string SkinName { get; set; }

    public FullScreenMode FullscreenMode { get; set; }

    public VSyncMode VSyncIndex { get; set; }

    public float Volume { get; set; }

    public float ElementsSize { get; set; }

    public float IncomingSpeed { get; set; }

    public Resolution Resolution { get; set; }

    public List<KeyCode> Keys { get; set; } = new List<KeyCode>();

    public override string ToString() =>
        $"{nameof(this.SkinName)}: {this.SkinName}, {nameof(this.FullscreenMode)}: {this.FullscreenMode}, {nameof(this.VSyncIndex)}: {this.VSyncIndex}, {nameof(this.Volume)}: {this.Volume}, {nameof(this.ElementsSize)}: {this.ElementsSize}, {nameof(this.Keys)}: {this.Keys}, {nameof(this.Resolution)}: {this.Resolution}";
}