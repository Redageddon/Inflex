using System;
using System.IO;
using System.Linq;
using Audio;
using Inflex.Rron;
using SceneLessLogic.Beatmaps;
using UnityEngine;
using UnityEngine.Networking;
using static System.Threading.SpinWait;


namespace SceneLessLogic
{
    public static class FileLoader
    {
        public static Texture2D LoadTexture2D(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }

            var       fileData = File.ReadAllBytes(path);
            Texture2D tex2D    = new Texture2D(0, 0);
            return tex2D.LoadImage(fileData) ? tex2D : null;
        }

        public static BeatMapMeta LoadBeatMap(string path)
        {
            string filePath = string.Equals(Path.GetExtension(path), ".rron")
                ? path
                : Directory.GetFiles(path, @"*.rron").First();
            BeatMapMeta prePath = RronConvert.DeserializeObjectFromFile<BeatMapMeta>(filePath);
            prePath.Path = path;
            return prePath;
        }

        public static AudioClip LoadAudioClip(string path)
        {
            Uri                   uriPath = new Uri(path);
            using UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip(uriPath, AudioType.UNKNOWN);
            request.SendWebRequest();
            SpinUntil(() => request.isDone);

            return Path.GetExtension(path) == ".mp3"
                ? Mp3ToAudioClip.FromMp3Bytes(request.downloadHandler.data)
                : DownloadHandlerAudioClip.GetContent(request);
        }
    }
}