using UnityEngine;
using UnityEngine.UI;

public static class BackgroundChanger
{
    public static void SetBackground(Image image, string path)
    {
        Texture2D texture = TextureLoader.LoadTexture(path);
        if (texture != null) image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
    }
}