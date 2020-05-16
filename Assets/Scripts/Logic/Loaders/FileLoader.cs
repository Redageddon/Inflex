using System;
using System.IO;
using System.Linq;
using BeatMaps;
using Components.Audio;
using Inflex.Rron;
using UnityEngine;
using UnityEngine.Networking;
using static System.Threading.SpinWait;


namespace Logic.Loaders
{
    public static class FileLoader
    {
        public static Texture2D LoadTexture2D(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }

            byte[] fileData = File.ReadAllBytes(path);
            Texture2D tex2D = new Texture2D(0, 0);
            return tex2D.LoadImage(fileData) ? tex2D : null;
        }

        public static BeatMap LoadBeatMap(string path)
        {
            string filePath = string.Equals(Path.GetExtension(path), ".rron")
                ? path
                : Directory.GetFiles(path, @"*.rron").First();

            BeatMap prePath = RronConvert.DeserializeObjectFromFile<BeatMap>(filePath);
            prePath.Path = path;
            return prePath;
        }

        public static AudioClip LoadAudioClip(string path)
        {
            Uri uriPath = new Uri(path);
            using (UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip(uriPath, AudioType.UNKNOWN))
            {
                request.SendWebRequest();
                SpinUntil(() => request.isDone);

                return Path.GetExtension(path) == ".mp3"
                    ? Mp3ToAudioClip.FromMp3Bytes(request.downloadHandler.data)
                    : DownloadHandlerAudioClip.GetContent(request);
            }
        }
    }
}