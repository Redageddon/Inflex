using UnityEngine.SceneManagement;

public class MainMenuButton : Button
{
    protected override void Left() => SceneManager.LoadScene("LevelSelection", LoadSceneMode.Single);
}