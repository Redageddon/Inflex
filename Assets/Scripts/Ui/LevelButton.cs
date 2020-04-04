using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : VisibleElement
{
    [SerializeField] private Text levelNameText;
    [SerializeField] private Text difficulty;
    public LevelData levelData;
    
    private void Start()
    {
        SetButtonData();
    }

    private void SetButtonData()
    {
        levelNameText.text = levelData.Title;
        difficulty.text = levelData.Difficulty.ToString();
    }

    private void OnClicked()
    {
        //background.sprite = SpriteLoader.Instance.GetSprite(Path.Combine(levelData.Path, levelData.Icon));
        AssetLoader.Instance.Level = LevelLoader.Instance.Load(levelData.Path);
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}