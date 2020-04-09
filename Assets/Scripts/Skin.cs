using System.Collections.Generic;
using UnityEngine;

public class Skin
{
    public Skin(string skinPath, string skinName)
    {
        if (skinName != "Default") return;
        skinPath += skinName;
            BackButton = Texture2DLoader.Instance.Load($"{skinPath}/BackButton.png");
            Background = Texture2DLoader.Instance.Load($"{skinPath}/Background.png");
            Center = Texture2DLoader.Instance.Load($"{skinPath}/Center.png");
            CurrentKeys = new List<Texture2D>
            {
                Texture2DLoader.Instance.Load($"{skinPath}/CurrentKey1.png"),
                Texture2DLoader.Instance.Load($"{skinPath}/CurrentKey2.png"),
                Texture2DLoader.Instance.Load($"{skinPath}/CurrentKey3.png"),
                Texture2DLoader.Instance.Load($"{skinPath}/CurrentKey4.png")
            };
            HitObjects = new List<Texture2D>
            {
                Texture2DLoader.Instance.Load($"{skinPath}/HitObject1.png"),
                Texture2DLoader.Instance.Load($"{skinPath}/HitObject2.png"),
                Texture2DLoader.Instance.Load($"{skinPath}/HitObject3.png"),
                Texture2DLoader.Instance.Load($"{skinPath}/HitObject4.png")
            };
            Pointer = Texture2DLoader.Instance.Load($"{skinPath}/Pointer.png");
            LevelButton = Texture2DLoader.Instance.Load($"{skinPath}/LevelButton.png");
            PauseButton = Texture2DLoader.Instance.Load($"{skinPath}/PauseButton.png");
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