using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using Newtonsoft.Json;

using static System.IO.Directory;

public class MapCreator : MonoBehaviour
{
    private readonly string[] _mapNames =
        GetDirectories(System.Environment.ExpandEnvironmentVariables(@"%AppData%\CircleRhythm\Maps\"));

    [SerializeField] private GameObject mapButtonTemp;

    void Start()
    {

        Map mapTest = new Map()
        {
            Background = "",
            Lives = 3,
            Song = "Ghost",
            EndTime = 10,
            MetaData = new MapMetaData()
            {
                Artist = "camellia",
                Title = "mapTest",
                Creator = "Rubik"
            },
            Enemies = new List<Enemy>()
            {
                new Enemy()
                {
                    Rotation = 10,
                    KillKey = "W",
                    SpawnTime = 1,
                    XLocation = 100,
                    YLocation = 200
                },
                new Enemy()
                {
                    Rotation = 10,
                    KillKey = "W",
                    SpawnTime = 1,
                    XLocation = 100,
                    YLocation = 200
                },
            },
            ScreenEvents = new List<MapScreen>()
            {
                new MapScreen()
                {
                    Zoom = 10,
                    RotationSpeed = 10,
                    SpawnTime = 2
                },
                new MapScreen()
                {
                    Zoom = 10,
                    RotationSpeed = 10,
                    SpawnTime = 2
                }
            }
        };
        string json = JsonConvert.SerializeObject(mapTest, (Formatting) 1);
        File.WriteAllText(@"C:\Users\Rubiksmaster02\AppData\Roaming\CircleRhythm\Maps\json.json",json);

        foreach (string map in _mapNames)
        {
            GameObject button = Instantiate(mapButtonTemp, mapButtonTemp.transform.parent, false);
            button.SetActive(true);
            button.GetComponent<MapButton>().SetText(Path.GetFileName(map));
            MapButton mapBtn = button.GetComponent<MapButton>();
            mapBtn.ButtonInstancePath = map;
        }
    }

    private static string _csvPath;

    public static void LoadPath(string path)
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
        _csvPath = GetFiles(path, @"*.csv").First();
    }
}