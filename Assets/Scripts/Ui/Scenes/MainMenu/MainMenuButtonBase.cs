using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonBase : ButtonBase
{
    [SerializeField] private string navigation;
    protected override void Left() => SceneManager.LoadScene(navigation, LoadSceneMode.Single);
}