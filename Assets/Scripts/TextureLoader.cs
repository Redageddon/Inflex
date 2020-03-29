using System.IO;
using UnityEngine;

public static class TextureLoader
{
    public static Texture2D LoadTexture(string filePath)
    {
        if (!File.Exists(filePath)) return null;
        var fileData = File.ReadAllBytes(filePath);
        var tex2D = new Texture2D(0, 0);
        return tex2D.LoadImage(fileData) ? tex2D : null;
    }
}