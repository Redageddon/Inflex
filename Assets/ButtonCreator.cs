using UnityEngine;
using System.IO;

public class ButtonCreator : MonoBehaviour
{
    [SerializeField] private GameObject mapButtonTemp;
    private readonly string[] _mapNames =
       Directory.GetDirectories(System.Environment.ExpandEnvironmentVariables(@"%AppData%\CircleRhythm\Maps\"));

    private void Start()
    {
        CreateMapButtons();
    }

    private void CreateMapButtons()
    {
        foreach (string map in _mapNames)
        {
            GameObject button = Instantiate(mapButtonTemp, mapButtonTemp.transform.parent, false);
            button.SetActive(true);
            button.GetComponent<MapButton>().map = JsonLoader.LoadMap(map);
        }
    }
}