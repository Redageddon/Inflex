using UnityEngine;
using System.IO;


public class ButtonCreator : MonoBehaviour
{
    private readonly string[] _mapNames =
       Directory.GetDirectories(System.Environment.ExpandEnvironmentVariables(@"%AppData%\CircleRhythm\Maps\"));

    [SerializeField] 
    private GameObject mapButtonTemp;

    void Start()
    {
        /*
        Map mapTest = new Map()
        {
            MetaData = new MapMetaData()
            {
                Artist = "camellia",
                Title = "mapTest",
                Creator = "Rubik",
                Icon = "img.jpg"
            },
            Background = "img.jpg",
            Lives = 3,
            Song = "Ghost",
            EndTime = 10,
            Enemies = new System.Collections.Generic.List<Enemy>()
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
            ScreenEvents = new System.Collections.Generic.List<MapScreen>()
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
        string json = Newtonsoft.Json.JsonConvert.SerializeObject(mapTest, (Newtonsoft.Json.Formatting) 1);
        File.WriteAllText(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
            @"CircleRhythm\Maps\test.json"),json);*/

        foreach (string map in _mapNames)
        {
            GameObject button = Instantiate(mapButtonTemp, mapButtonTemp.transform.parent, false);
            button.SetActive(true);
            button.GetComponent<MapButton>().SetText(Path.GetFileName(map));
            button.GetComponent<MapButton>().ButtonInstancePath = map;
        }
    }
}