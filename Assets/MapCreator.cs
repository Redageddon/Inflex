using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.IO.Directory;

public class MapCreator : MonoBehaviour
{
    private static string _csvPath;

    public static void LoadPath(string path)
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
        _csvPath = GetFiles(path,@"*.csv").First();
        //Parse(File.ReadAllLines(_csvPath, Encoding.ASCII));
        Parse();
    }
    /*
    private static void Parse(string[] file)
    {
        foreach (var line in file)
        {
           
        }
    }*/
    private static void Parse()
    {
        EnemyO enemy1 = new EnemyO("Enemy", "W", 200, 200, 0, 1.1);
    }

}
