using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : Button
{
    [SerializeField] private Text levelNameText;
    [SerializeField] private Text difficulty;
    [SerializeField] private GameObject levelButtonControl;
    private LevelData levelData;

    public void SetButtonData(LevelData data)
    {
        levelData = data;
        image.texture = Assets.Instance.Skin.LevelButton ? Assets.Instance.Skin.LevelButton : image.texture;
        image.SetNativeSize();
        levelNameText.text = levelData.Title;
        difficulty.text = levelData.Difficulty.ToString();
    }

    protected override void Left()
    {
        Assets.Instance.Level = LevelLoader.Load(levelData.Path);
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    protected override void Right()
    {
        levelButtonControl.SetActive(true);
        levelButtonControl.transform.Find("DeleteMap").GetComponent<DeleteMapButton>().DeletionIndex = levelData.Id;
        levelButtonControl.transform.Find("DeleteMap").GetComponent<DeleteMapButton>().DeletionButton = gameObject;
    }
}