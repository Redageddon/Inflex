using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : Button
{
    [SerializeField] private Text levelNameText;
    [SerializeField] private Text difficulty;
    private LevelData levelData;

    public void SetButtonData(LevelData levelData)
    {
        this.levelData = levelData;
        image.texture = Assets.Instance.Skin.LevelButton ? Assets.Instance.Skin.LevelButton : image.texture;
        image.SetNativeSize();
        levelNameText.text = levelData.Title;
        difficulty.text = levelData.Difficulty.ToString();
    }

    public override void OnClicked(string navigation)
    {
        Assets.Instance.Level = LevelLoader.Load(levelData.Path);
        SceneManager.LoadScene(navigation, LoadSceneMode.Single);
    }
}