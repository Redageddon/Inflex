using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private string scene;
    public void OpenScene()
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
