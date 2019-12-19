/*
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class BGChange : MonoBehaviour
{
    public Image img;
    private static string MainPath { get; } = @"%AppData%\CircleRhythm\Maps\";
    static string MapName { get; set; }
    static string FileName { get; set; }


    private static Texture2D LoadTexture(string filePath)
    {
        if (File.Exists(filePath))
        {
            byte[] fileData = File.ReadAllBytes(filePath);
            Texture2D tex2D = new Texture2D(2, 2);
            if (tex2D.LoadImage(fileData)) { return tex2D; }
        }
        return null;
    }

    private void Start()
    {
        MapName = @"Map1\";
        FileName = "bg1.png";
        string fullPath = System.Environment.ExpandEnvironmentVariables(MainPath + MapName + FileName);
        print(fullPath);
        if (LoadTexture(fullPath) != null)
        {
            img.sprite = Sprite.Create(LoadTexture(fullPath),
                new Rect(0, 0, LoadTexture(fullPath).width, LoadTexture(fullPath).height), new Vector2(0, 0));
        }
    }
}
*/