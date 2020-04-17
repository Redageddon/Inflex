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
        image.texture = Assets.Instance.Skin.LevelButton ? Assets.Instance.Skin.LevelButton : image.texture;
        image.SetNativeSize();
        levelNameText.text = levelData.Title;
        difficulty.text = levelData.Difficulty.ToString();
    }

    protected override void Left()
    {
        Assets.Instance.Level = JsonLoader.LoadLevel(levelData.Path);
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
        AudioPlayer.Instance.LoadAudio($"{Assets.Instance.Level.Path}/{Assets.Instance.Level.SongFile}");
        AudioHelper.SetOffset();
        AudioPlayer.Instance.PlayGameSong();
    }

    protected override void Right()
    {
        levelButtonOptions.SetActive(true);
        levelButtonOptions.transform.Find("DeleteMap").GetComponent<DeleteMapButton>().deletionIndex = levelData.Id;
        levelButtonOptions.transform.Find("DeleteMap").GetComponent<DeleteMapButton>().deletionButton = gameObject;
    }
}