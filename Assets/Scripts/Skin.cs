using System;
using System.Collections.Generic;
using UnityEngine;

public class Skin
{
    public Skin(string skinPath, string skinName)
    {
        if (!string.Equals(skinName, "Default", StringComparison.OrdinalIgnoreCase))
        {
            CurrentKeys = new List<Texture2D>();
            HitObjects = new List<Texture2D>();
            return;
        }

        skinPath += skinName;
            BackButton = Loader.LoadTexture2D($"{skinPath}/BackButton.png");
            Background = Loader.LoadTexture2D($"{skinPath}/Background.png");
            Center = Loader.LoadTexture2D($"{skinPath}/Center.png");
            CurrentKeys = new List<Texture2D>
            {
                Loader.LoadTexture2D($"{skinPath}/CurrentKey1.png"),
                Loader.LoadTexture2D($"{skinPath}/CurrentKey2.png"),
                Loader.LoadTexture2D($"{skinPath}/CurrentKey3.png"),
                Loader.LoadTexture2D($"{skinPath}/CurrentKey4.png")
            };
            HitObjects = new List<Texture2D>
            {
                Loader.LoadTexture2D($"{skinPath}/HitObject1.png"),
                Loader.LoadTexture2D($"{skinPath}/HitObject2.png"),
                Loader.LoadTexture2D($"{skinPath}/HitObject3.png"),
                Loader.LoadTexture2D($"{skinPath}/HitObject4.png")
            };
            Pointer = Loader.LoadTexture2D($"{skinPath}/Pointer.png");
            LevelButton = Loader.LoadTexture2D($"{skinPath}/LevelButton.png");
            PauseButton = Loader.LoadTexture2D($"{skinPath}/PauseButton.png");
    }

    public Texture2D Background { get; }
    public Texture2D Center { get; }
    public Texture2D Pointer { get; }
    public List<Texture2D> HitObjects { get; }
    public List<Texture2D> CurrentKeys { get; }
    public Texture2D PauseButton { get; }
    public Texture2D LevelButton { get; }
    public Texture2D BackButton { get; }
}