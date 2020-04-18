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
        string json = File.ReadAllText(path);
        T obj = JsonConvert.DeserializeObject<T>(json);
        return (T) Convert.ChangeType(obj, typeof(T));
    }

    public static Texture2D LoadTexture2D(string path)
    {
        if (!File.Exists(path)) return null;
        byte[] fileData = File.ReadAllBytes(path);
        Texture2D tex2D = new Texture2D(0, 0);
        return tex2D.LoadImage(fileData) ? tex2D : null;
    }

    public static Level LoadLevel(string path)
    {
        string json = Directory.GetFiles(path, @"*.json").First();
        string data = File.ReadAllText(json);
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
                ? Mp3ToAudioClip.FromMp3Bytes(request.downloadHandler.data)
                : DownloadHandlerAudioClip.GetContent(request);
        }
    }

    public static void Save(object toSave, string path)
    {
        string json = JsonConvert.SerializeObject(toSave, Formatting.Indented);
        File.WriteAllText(path, json);
    }
}