using System.Collections.Generic;
using UnityEngine;

public class Skin
{
    public Texture2D Background { get; set; }
    public Texture2D Center { get; set; }
    public Texture2D Pointer { get; set; }
    public List<Texture2D> HitObjects { get; set; }
    public List<Texture2D> CurrentKeys { get; set; }
    public Texture2D PauseButton { get; set; }
    public Texture2D LevelButton { get; set; }
    public Texture2D BackButton { get; set; }
}