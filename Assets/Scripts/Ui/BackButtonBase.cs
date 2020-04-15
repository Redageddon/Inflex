using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonBase : ButtonBase
{
    [SerializeField] private string navigation;
    private void Start() => image.texture = Assets.Instance.Skin.BackButton ? Assets.Instance.Skin.BackButton : image.texture;

    protected override void Left() => SceneManager.LoadScene(navigation, LoadSceneMode.Single);
}