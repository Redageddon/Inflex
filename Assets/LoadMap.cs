using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using Newtonsoft.Json;

public class LoadMap : MonoBehaviour
{
    private static string _csvPath;
    public static void LoadPath(string path)
    {
        _csvPath = Directory.GetFiles(path, @"*.json").First();
        string json = File.ReadAllText(_csvPath);
        Map currentMap = JsonConvert.DeserializeObject<Map>(json);
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
