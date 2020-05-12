using System.IO;
using System.Linq;
using Inflex.Rron;
using UnityEngine;
using UnityEngine.Networking;
using static System.Threading.SpinWait;

public static class Loader
{
    public static Texture2D LoadTexture2D(string path)
    {
        if (!File.Exists(path)) return null;
        byte[] fileData = File.ReadAllBytes(path);
        Texture2D tex2D = new Texture2D(0, 0);
        return tex2D.LoadImage(fileData) ? tex2D : null;
    }

    public static Level LoadLevel(string path)
    {
        string filePath = Directory.GetFiles(path, @"*.rron").First();
        Level prePath = RronConvert.DeserializeObjectFromFile<Level>(filePath);
        prePath.Path = path;
        return prePath;
    }

    public static AudioClip LoadAudioClip(string path)
    {
        using (UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.UNKNOWN))
        {
            request.SendWebRequest();
            SpinUntil(() => request.isDone);
            
            return Path.GetExtension(path) == ".mp3"
                ? Mp3ToAudioClip.FromMp3Bytes(request.downloadHandler.data)
                : DownloadHandlerAudioClip.GetContent(request);
        }
    }
}