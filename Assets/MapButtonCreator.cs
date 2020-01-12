/*using System.IO;
using UnityEngine;

public class MapButtonCreator : MonoBehaviour
{
    [SerializeField] private GameObject mapButtonTemp;
    void Start()
    {
        foreach(string map in PathData.MapNames)
        {
            GameObject button = Instantiate(mapButtonTemp, mapButtonTemp.transform.parent, false);
            button.SetActive(true);
            button.GetComponent<MapButton>().SetText(Path.GetFileName(map));
            MapButton mapBtn = button.GetComponent<MapButton>();
            mapBtn.ButtonInstancePath = map;
        }
    }
}
*/