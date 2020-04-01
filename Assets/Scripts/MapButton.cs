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

    public void OnClicked()
    {
        BackgroundChanger.SetBackground(background, Path.Combine(levelData.Path, levelData.Icon));
        MapHandler.UpdatePublicMap(levelData.Path);
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}