using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapButton : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private Text mapNameText;
    [SerializeField] private Text difficulty;
    internal Map Map;
    

    private void Start()
    {
        SetButtonData();
    }

    private void SetButtonData()
    {
        mapNameText.text = Map.MetaData.Title;
        difficulty.text = "00"; //not implemented yet
    }

    private bool _selected;
    public void Select()
    {
        _selected = true;
        BackgroundChanger.SetBackground(background, Path.Combine(Map.Path, Map.MetaData.Icon));
    }

    public void OnClick()
    {
        if (!_selected || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Mouse0))
        {
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
            GameControl.MapName = Map.Path;
        }

        else _selected = false;
    }
}