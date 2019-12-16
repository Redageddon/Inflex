using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class BGChange : MonoBehaviour
{

    public Image img;
    public static Texture2D LoadTexture(string FilePath)
    {
        
        Texture2D Tex2D;
        byte[] FileData;

        if (File.Exists(FilePath))
        {
            FileData = File.ReadAllBytes(FilePath);
            Tex2D = new Texture2D(2, 2);
            if (Tex2D.LoadImage(FileData)) {return Tex2D;}
        }

        return null;
    }

    private void Start()
    {
        string file = "C:\\Users\\Rubiksmaster02\\Desktop\\bg1.png";
        img.sprite = Sprite.Create(LoadTexture(file), new Rect(0, 0, LoadTexture(file).width, LoadTexture(file).height), new Vector2(0, 0));
    }
}