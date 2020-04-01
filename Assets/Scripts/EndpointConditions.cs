using UnityEngine;
using UnityEngine.SceneManagement;

public class EndpointConditions : MonoBehaviour
{
    public static void GameWin()
    {
        SceneManager.LoadScene("MapSelection", LoadSceneMode.Single);
    }

    public static void GameLose()
    {
        SceneManager.LoadScene("MapSelection", LoadSceneMode.Single);
    }
}