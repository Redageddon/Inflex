using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using UnityEngine;

public class MapSelectionControl : MonoBehaviour
{
    [SerializeField] private GameObject mapButtonTemp;
    private static readonly string MapsLocation = Environment.ExpandEnvironmentVariables(@"%AppData%\CircleRhythm\Maps\");
    private readonly string[] _mapNames = Directory.GetDirectories(MapsLocation);

    private void Start()
    {
        ButtonCreator.CreateMapButtons(_mapNames.Length == 0 ? DownloadDefaultMap() : _mapNames, mapButtonTemp);
    }

    private static string[] DownloadDefaultMap()
    {
        string fileName = MapsLocation + "DefaultMap";
        WebClient defaultMap = new WebClient();
        defaultMap.DownloadFile("https://raw.githubusercontent.com/rubiksmaster02/CircleRhythmDB/master/Map1.zip", fileName + ".zip");
        ZipFile.ExtractToDirectory(fileName + ".zip", fileName);
        File.Delete(fileName + ".zip");
        return new[]{fileName};
    }
}