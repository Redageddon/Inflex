using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;
using static System.Threading.SpinWait;

public static class JsonLoader
{
    public static T Load<T>(string path)
    {
        var json = File.ReadAllText(path);
        var obj = JsonConvert.DeserializeObject<T>(json);
        return (T) Convert.ChangeType(obj, typeof(T));
    }

    public static Texture2D LoadTexture2D(string path)
    {
        if (!File.Exists(path)) return null;
        var fileData = File.ReadAllBytes(path);
        var tex2D = new Texture2D(0, 0);
        return tex2D.LoadImage(fileData) ? tex2D : null;
    }

    public static Level LoadLevel(string path)
    {
        var json = Directory.GetFiles(path, @"*.json").First();
        var data = File.ReadAllText(json);
        JObject prePath = JObject.Parse(data);
        prePath.Add("Path", path);
        return prePath.ToObject<Level>();
    }

    public static AudioClip LoadAudioClip(string path)
    {
        using (UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.UNKNOWN))
        {
            request.SendWebRequest();
            SpinUntil(() => request.isDone);
            return Path.GetExtension(path) == ".mp3"
                ? AudioClipFromMp3.FromBytes(request.downloadHandler.data)
                : DownloadHandlerAudioClip.GetContent(request);
        }
    }

    public static void Save(object toSave, string path)
    {
        var json = JsonConvert.SerializeObject(toSave, Formatting.Indented);
        File.WriteAllText(path, json);
    }
}