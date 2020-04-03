using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapButton : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private Text mapNameText;
    [SerializeField] private Text difficulty;
    public LevelData levelData;
    
    private void Start()
    {
        SetButtonData();
    }

    private void SetButtonData()
    {
        mapNameText.text = levelData.Title;
    }

    private void OnClicked()
    {
        background.sprite = SpriteLoader.Instance.GetSprite(Path.Combine(levelData.Path, levelData.Icon));
        MapHandler.Instance.Map = MapHandler.Instance.Load(levelData.Path);
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}