using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class AudioClipLoader : Singleton<AudioClipLoader>, ILoader<AudioClip>
{
    public AudioClip Load(string path)
    {
        using (UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.UNKNOWN))
        {
            request.SendWebRequest();
            System.Threading.SpinWait.SpinUntil(() => request.isDone);
            return Path.GetExtension(path) == ".mp3" ? AudioClipFromMp3.FromBytes(request.downloadHandler.data) : DownloadHandlerAudioClip.GetContent(request);
        }
    }

    public void Save(string path)
    {
        Debug.LogWarning("This has not been Implemented");
        throw new System.NotImplementedException();
    }
}