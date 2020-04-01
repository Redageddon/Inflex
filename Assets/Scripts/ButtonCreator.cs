using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCreator : MonoBehaviour
{
    [SerializeField] private GameObject mapButtonTemp;

    public void Start()
    {
        var mapNames = LevelDataSerializer.GetAllLevelsData();
        if(mapNames == null) return;
        foreach (var mapName in mapNames)
        {
            CreateMapButton(mapName);
        }
    }
    
    private void Update()
    {
        CheckForMapsRefreshMacro();
    }

    private void CheckForMapsRefreshMacro()
    {
        if (!Input.GetKey(KeyCode.LeftControl)) return;
        if (!Input.GetKeyDown(KeyCode.R)) return;
        LevelDataSerializer.RefreshAllLevelsData();
        SceneManager.LoadScene("MapSelection", LoadSceneMode.Single);
    }

    private void CreateMapButton(LevelData level)
    {
        GameObject button = Instantiate(mapButtonTemp, mapButtonTemp.transform.parent, false);
        button.SetActive(true);
        button.GetComponent<MapButton>().levelData = level;
    }
}