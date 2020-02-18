using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapButton : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private Text mapNameText;
    [SerializeField] private Text artist;
    [SerializeField] private Text enemyCount;
    [SerializeField] private Text difficulty;
    [SerializeField] private Text creator;
    private Map map;
    internal string MapName;
    private bool _selected;

    private void Start()
    {
        map = JsonLoader.LoadMap(MapName);
        SetButtonData();
    }

    private void SetButtonData()
    {
        mapNameText.text = map.MetaData.Title;
        enemyCount.text = "Enemy Count: " + map.Enemies.Count;
        difficulty.text = "00"; //not implemented yet
        creator.text = map.MetaData.Creator;
        artist.text = map.MetaData.Artist;
    }

    public void Select()
    {
        _selected = true;
        BackgroundChanger.SetBackground(background, Path.Combine(map.Path, map.MetaData.Icon));
    }

    public void OnClick()
    {
        if (!_selected || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Mouse0))
        {
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
            GameControl.MapName = MapName;
        }

        else _selected = false;
    }
}