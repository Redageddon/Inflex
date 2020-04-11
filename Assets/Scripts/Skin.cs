using System.Collections.Generic;
using UnityEngine;

public class Skin
{
    public Skin(string skinPath, string skinName)
    {
        if (skinName != "Default")
        {
            CurrentKeys = new List<Texture2D>();
            HitObjects = new List<Texture2D>();
            return;
        }

        skinPath += skinName;
            BackButton = Texture2DLoader.Load($"{skinPath}/BackButton.png");
            Background = Texture2DLoader.Load($"{skinPath}/Background.png");
            Center = Texture2DLoader.Load($"{skinPath}/Center.png");
            CurrentKeys = new List<Texture2D>
            {
                Texture2DLoader.Load($"{skinPath}/CurrentKey1.png"),
                Texture2DLoader.Load($"{skinPath}/CurrentKey2.png"),
                Texture2DLoader.Load($"{skinPath}/CurrentKey3.png"),
                Texture2DLoader.Load($"{skinPath}/CurrentKey4.png")
            };
            HitObjects = new List<Texture2D>
            {
                Texture2DLoader.Load($"{skinPath}/HitObject1.png"),
                Texture2DLoader.Load($"{skinPath}/HitObject2.png"),
                Texture2DLoader.Load($"{skinPath}/HitObject3.png"),
                Texture2DLoader.Load($"{skinPath}/HitObject4.png")
            };
            Pointer = Texture2DLoader.Load($"{skinPath}/Pointer.png");
            LevelButton = Texture2DLoader.Load($"{skinPath}/LevelButton.png");
            PauseButton = Texture2DLoader.Load($"{skinPath}/PauseButton.png");
    }

    public Texture2D Background { get; set; }
    public Texture2D Center { get; set; }
    public Texture2D Pointer { get; set; }
    public List<Texture2D> HitObjects { get; set; }
    public List<Texture2D> CurrentKeys { get; set; }
    public Texture2D PauseButton { get; set; }
    public Texture2D LevelButton { get; set; }
    public Texture2D BackButton { get; set; }
}