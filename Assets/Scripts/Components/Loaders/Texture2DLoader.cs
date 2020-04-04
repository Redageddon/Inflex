using System.IO;
using UnityEngine;

public class Texture2DLoader : Singleton<Texture2DLoader>, ILoader<Texture2D>
{
    public Texture2D Load(string path)
    {
        if (!File.Exists(path)) return null;
        var fileData = File.ReadAllBytes(path);
        var tex2D = new Texture2D(0, 0);
        return tex2D.LoadImage(fileData) ? tex2D : null;
    }

    public void Save(string path)
    {
        Debug.LogWarning("This has not been Implemented");
        throw new System.NotImplementedException();
    }
}