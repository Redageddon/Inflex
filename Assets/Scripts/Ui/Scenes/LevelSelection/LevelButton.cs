using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : ButtonBase
{
    [SerializeField] private Text levelNameText;
    [SerializeField] private Text difficulty;
    [SerializeField] private GameObject levelButtonOptions;
    private LevelData levelData;

    public void SetButtonData(LevelData data)
    {
        levelData = data;
        image.texture = Assets.Instance.Skin.LevelButton 
            ? Assets.Instance.Skin.LevelButton 
            : image.texture;
        image.SetNativeSize();
        levelNameText.text = levelData.Title;
        difficulty.text = levelData.Difficulty.ToString();
    }

    protected override void Left()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
        Assets.Instance.Level = Loader.LoadLevel(levelData.Path);
    }

    protected override void Right()
    {
        levelButtonOptions.SetActive(true);
        levelButtonOptions.transform.Find("DeleteMap").GetComponent<DeleteMapButton>().deletionIndex = levelData.Id;
        levelButtonOptions.transform.Find("DeleteMap").GetComponent<DeleteMapButton>().deletionButton = gameObject;
    }
}