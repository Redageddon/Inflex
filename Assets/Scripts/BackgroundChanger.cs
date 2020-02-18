using System.IO;
using UnityEngine;
using UnityEngine.UI;

public static class BackgroundChanger
{
    private static Texture2D LoadTexture(string filePath)
    {
        if (!File.Exists(filePath)) return null;
        byte[] fileData = File.ReadAllBytes(filePath);
        Texture2D tex2D = new Texture2D(0, 0);
        return tex2D.LoadImage(fileData) ? tex2D : null;
    }
    
    public static void SetBackground(Image image, string path)
    {
        Texture2D texture = LoadTexture(path);
        if (texture != null) image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
    }
}