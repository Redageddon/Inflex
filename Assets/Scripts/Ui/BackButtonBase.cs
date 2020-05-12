using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonBase : ButtonBase
{
    [SerializeField] private string navigation;

    protected override void Left() => SceneManager.LoadScene(this.navigation, LoadSceneMode.Single);

    private void Start() => this.Image.texture = Assets.Instance.Skin.BackButton ? Assets.Instance.Skin.BackButton : this.Image.texture;
}