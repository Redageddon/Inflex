using UnityEngine;
using System.IO;

public class MapSelectionControl : MonoBehaviour
{
    [SerializeField] private GameObject mapButtonTemp;
    private readonly string[] _mapNames =
        Directory.GetDirectories(System.Environment.ExpandEnvironmentVariables(@"%AppData%\CircleRhythm\Maps\"));

    private void Start()
    {
        ButtonCreator.CreateMapButtons(_mapNames ,mapButtonTemp);
    }
}