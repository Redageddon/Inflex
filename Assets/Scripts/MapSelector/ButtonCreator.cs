using UnityEngine;

public class ButtonCreator : Object
{
    public static void CreateMapButtons(string[] mapNames, GameObject mapButton)
    {
        foreach (var map in mapNames)
        {
            GameObject button = Instantiate(mapButton, mapButton.transform.parent, false);
            button.SetActive(true);
            button.GetComponent<MapButton>().Map = JsonLoader.LoadMap(map);
        }
    }
}