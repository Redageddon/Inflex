using System;
using System.Collections.Generic;
using Logic;
using UnityEngine;

public class Skin
{
    public Skin(string skinPath, string skinName)
    {
        if (!string.Equals(skinName, "Default", StringComparison.OrdinalIgnoreCase))
        {
            skinPath        += skinName;
            this.BackButton =  FileLoader.LoadTexture2D($"{skinPath}/BackButton.png");
            this.Background =  FileLoader.LoadTexture2D($"{skinPath}/Background.png");
            this.Center     =  FileLoader.LoadTexture2D($"{skinPath}/Center.png");
            this.CurrentKeys = new List<Texture2D>
            {
                FileLoader.LoadTexture2D($"{skinPath}/CurrentKey1.png"),
                FileLoader.LoadTexture2D($"{skinPath}/CurrentKey2.png"),
                FileLoader.LoadTexture2D($"{skinPath}/CurrentKey3.png"),
                FileLoader.LoadTexture2D($"{skinPath}/CurrentKey4.png")
            };
            this.HitObjects = new List<Texture2D>
            {
                FileLoader.LoadTexture2D($"{skinPath}/HitObject1.png"),
                FileLoader.LoadTexture2D($"{skinPath}/HitObject2.png"),
                FileLoader.LoadTexture2D($"{skinPath}/HitObject3.png"),
                FileLoader.LoadTexture2D($"{skinPath}/HitObject4.png")
            };
            this.Pointer       = FileLoader.LoadTexture2D($"{skinPath}/Pointer.png");
            this.BeatMapButton = FileLoader.LoadTexture2D($"{skinPath}/LevelButton.png");
            this.PauseButton   = FileLoader.LoadTexture2D($"{skinPath}/PauseButton.png");
        }
    }

    public Texture2D Background { get; }

    public Texture2D Center { get; }

    public Texture2D Pointer { get; }

    public List<Texture2D> HitObjects { get; } = new List<Texture2D> {null, null, null, null};

    public List<Texture2D> CurrentKeys { get; } = new List<Texture2D> {null, null, null, null};

    public Texture2D PauseButton { get; }

    public Texture2D BeatMapButton { get; }

    public Texture2D BackButton { get; }
}