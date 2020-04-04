using UnityEngine;

public class SpriteLoader : Singleton<SpriteLoader>
{
    public Sprite GetSprite(string path)
    {
        Texture2D texture = Texture2DLoader.Instance.Load(path);
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
    }
}