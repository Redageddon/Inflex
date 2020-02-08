using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class BGChange : MonoBehaviour
{
    public Image img;

    private void Start()
    {
        SetBackground(img, Path.Combine(MapButton.Map.Path, MapButton.Map.Background));
    }
    
    private static Texture2D LoadTexture(string filePath)
    {
        if (!File.Exists(filePath)) return null;
        byte[] fileData = File.ReadAllBytes(filePath);
        Texture2D tex2D = new Texture2D(0, 0);
        return tex2D.LoadImage(fileData) ? tex2D : null;
    }
    
    public static void SetBackground(Image image, string path)
    {
        if (LoadTexture(path) != null)
        {
            image.sprite = Sprite.Create(LoadTexture(path),
                new Rect(0, 0, LoadTexture(path).width, LoadTexture(path).height), new Vector2(0, 0));
        }
    }
}