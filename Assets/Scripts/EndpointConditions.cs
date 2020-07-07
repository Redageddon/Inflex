using UnityEngine;
using UnityEngine.SceneManagement;

//Todo: actually add endpoints
public class EndpointConditions : MonoBehaviour
{
    public static void GameWin() => SceneManager.LoadScene("BeatMapSelection", LoadSceneMode.Single);

    public static void GameLose() => SceneManager.LoadScene("BeatMapSelection", LoadSceneMode.Single);
}