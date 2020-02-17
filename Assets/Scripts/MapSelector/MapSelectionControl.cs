using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using UnityEngine;

public class MapSelectionControl : MonoBehaviour
{
    [SerializeField] private GameObject mapButtonTemp;

    private readonly string[] _mapNames =
        Directory.GetDirectories(Environment.ExpandEnvironmentVariables(@"%AppData%\CircleRhythm\Maps\"));

    private void Start()
    {
        ButtonCreator.CreateMapButtons(_mapNames.Length == 0 ? DownloadDefaultMap() : _mapNames, mapButtonTemp);
    }

    private string[] DownloadDefaultMap()
    {
        WebClient defaultMap = new WebClient();
        var fileName = Environment.ExpandEnvironmentVariables(@"%AppData%\CircleRhythm\Maps\DefaultMap");
        defaultMap.DownloadFile("https://raw.githubusercontent.com/rubiksmaster02/CircleRhythmDB/master/Map1.zip", fileName + ".zip");
        ZipFile.ExtractToDirectory(fileName + ".zip", fileName);
        File.Delete(fileName + ".zip");
        return new[]{fileName};
    }
    
}