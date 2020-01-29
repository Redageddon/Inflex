using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class BGChange : MonoBehaviour
{
    public Image img;

    private static Texture2D LoadTexture(string filePath)
    {
        if (!File.Exists(filePath)) return null;
        byte[] fileData = File.ReadAllBytes(filePath);
        Texture2D tex2D = new Texture2D(0, 0);
        return tex2D.LoadImage(fileData) ? tex2D : null;
    }

    private void Start()
    {
        string path = MapButton.Map.Path;
        string image = MapButton.Map.Background;
        string fullPath = Path.Combine(path, image);
        if (LoadTexture(fullPath) != null)
        {
            img.sprite = Sprite.Create(LoadTexture(fullPath),
                new Rect(0, 0, LoadTexture(fullPath).width, LoadTexture(fullPath).height), new Vector2(0, 0));
        }
    }
}