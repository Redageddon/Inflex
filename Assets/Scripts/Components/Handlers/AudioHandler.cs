using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class AudioHandler : Singleton<AudioHandler>, IHandlerBase<AudioClip>
{
    public AudioClip Load(string path)
    {
        UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.UNKNOWN);
        request.SendWebRequest();
        System.Threading.SpinWait.SpinUntil(() => request.isDone);
        return Path.GetExtension(path) == ".mp3"
            ? Mp3Player.AudioClipFromMp3(request.downloadHandler.data)
            : DownloadHandlerAudioClip.GetContent(request);
    }

    public void Save(string path)
    {
        Debug.LogWarning("This has not been Implemented");
        throw new System.NotImplementedException();
    }
}