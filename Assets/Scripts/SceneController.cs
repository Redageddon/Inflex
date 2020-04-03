using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{
    public void OpenScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
