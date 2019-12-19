using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.IO.Directory;

public class MapCreator : MonoBehaviour
{
    private static string _csvPath;
    //Lives
    private string _lives;
    //Song
    private string _song;
    //Enemy
    private string[] _killKey;
    private string[] _xLoc;
    private string[] _yLoc;
    private string[] _iRotation;
    private string[] _eSpawnTime;
    //Screen
    private string[] _sRotationSpeed;
    private string[] _screenZoom;
    private string[] _sSpawnTime;
    //Background
    private string[] _bName;
    private string[] _bSpawnTime;
    //End
    private string _end;

    public static void LoadPath(string path)
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
        _csvPath = GetFiles(path,@"*.csv").First();
        Parse(File.ReadAllLines(_csvPath, Encoding.ASCII));
    }

    private static void Parse(string[] file)
    {
        foreach (var line in file)
        {
           
        }
    }
    
    
}
