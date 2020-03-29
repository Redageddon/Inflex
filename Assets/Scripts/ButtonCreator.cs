using UnityEngine;

public class ButtonCreator : MonoBehaviour
{
    [SerializeField] private GameObject mapButtonTemp;
    
    public void Start()
    {
        var mapNames = MapNamesReader.GetMapNames();
        foreach (var mapName in mapNames)
        {
            CreateMapButton(mapName);
        }
    }

    private void CreateMapButton(string mapName)
    {
        GameObject button = Instantiate(mapButtonTemp, mapButtonTemp.transform.parent, false);
        button.SetActive(true);
        button.GetComponent<MapButton>().Map =  MapHandler.LoadMap(mapName);
    }
}