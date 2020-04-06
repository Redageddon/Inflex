using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : Button
{
    [SerializeField] private Text levelNameText;
    [SerializeField] private Text difficulty;
    private Data _data;

    public void SetButtonData(Data data)
    {
        image.texture = Assets.Instance.Skin.LevelButton ? Assets.Instance.Skin.LevelButton : image.texture;
        image.SetNativeSize();
        _data = data;
        levelNameText.text = data.Title;
        difficulty.text = data.Difficulty.ToString();
    }

    public override void OnClicked(string navigation)
    {
        Assets.Instance.Level = LevelLoader.Instance.Load(_data.Path);
        SceneManager.LoadScene(navigation, LoadSceneMode.Single);
    }
}