using UnityEngine.SceneManagement;

public class Button : VisibleElement
{
    public virtual void OnClicked(string navigation)
    {
        SceneManager.LoadScene(navigation, LoadSceneMode.Single);
    }
}