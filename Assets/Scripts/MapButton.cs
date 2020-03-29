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
    }

    public void OnClicked()
    {
        BackgroundChanger.SetBackground(background, Path.Combine(Map.Path, Map.MetaData.Icon));
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
        GameControl.MapName = Map.Path;
    }
}