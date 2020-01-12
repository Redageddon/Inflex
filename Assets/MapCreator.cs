using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using static System.IO.Directory;

public class MapCreator : MonoBehaviour
{
    private readonly string[] MapNames = GetDirectories(System.Environment.ExpandEnvironmentVariables(@"%AppData%\CircleRhythm\Maps\"));
    
    [SerializeField] 
    private GameObject mapButtonTemp;
    
    void Start()
    {
        foreach(string map in MapNames)
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
        _csvPath = GetFiles(path,@"*.csv").First();
        //Parse(File.ReadAllLines(_csvPath, Encoding.ASCII));
    }
}
