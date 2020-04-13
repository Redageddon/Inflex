using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : Button
{
    [SerializeField] private string navigation;
    private void Update()
    {
        image.texture = Assets.Instance.Skin.BackButton ? Assets.Instance.Skin.BackButton : image.texture;
    }

    protected override void Left()
    {
        SceneManager.LoadScene(navigation, LoadSceneMode.Single);
    }
}