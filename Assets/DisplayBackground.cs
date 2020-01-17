using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DisplayBackground : MonoBehaviour
{
    public static void Display(RawImage image, string path) 
    {
        Texture2D tex = new Texture2D(0, 0);
        tex.LoadImage(File.ReadAllBytes(path));
        image.GetComponent<RawImage>().texture = tex;
    }
}
