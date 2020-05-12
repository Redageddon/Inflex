using System.Globalization;
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
        this.levelData = data;
        this.Image.texture = Assets.Instance.Skin.LevelButton
            ? Assets.Instance.Skin.LevelButton
            : this.Image.texture;
        this.Image.SetNativeSize();
        this.levelNameText.text = this.levelData.Title;
        this.difficulty.text = this.levelData.Difficulty.ToString(CultureInfo.CurrentCulture);
    }

    protected override void Left()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
        Assets.Instance.Level = Loader.LoadLevel(this.levelData.Path);
    }

    protected override void Right()
    {
        this.levelButtonOptions.SetActive(true);
        this.levelButtonOptions.transform.Find("DeleteMap").GetComponent<DeleteMapButton>().DeletionIndex = this.levelData.Id;
        this.levelButtonOptions.transform.Find("DeleteMap").GetComponent<DeleteMapButton>().DeletionButton = this.gameObject;
    }
}