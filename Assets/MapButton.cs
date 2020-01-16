using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapButton : MonoBehaviour
{
    [SerializeField] private Text mapName;
    [SerializeField] private Text enemyCount;
    [SerializeField] private Text difficulty;
    [SerializeField] private Text creator;
    public Map map;

    private void Start()
    {
        mapName.text = map.MetaData.Title;
        enemyCount.text = "Enemy Count: " + map.Enemies.Count;
        difficulty.text = "00"; //not implemented yet
        creator.text = map.MetaData.Creator;
    }

    public void OnMouseOver()
    {
        //print("over");
    }
    public void OnSelect()
    {
        print("selected");
    }
    public void OnDeselect()
    {
        print("deselected");
    }

    public void OnClick()
    {
        // check selected
        //SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }    
}