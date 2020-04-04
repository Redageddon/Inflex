using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    public static bool GamePaused;
    private int currentSpeed;

    public void OnGUI()
    {
        UpdatePause();
    }

    private void Update()
    {
        UpdatePause();
    }

    private void UpdatePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamePaused = !GamePaused;
            pauseScreen.SetActive(GamePaused);
        }
        if (!GamePaused)
        {
            AudioPlayer.Instance.audioSource.UnPause();
        }
        else
        {
            AudioPlayer.Instance.audioSource.Pause();
        }
    }
    
    public static float GetSpeed(int currentEnemy)
    {
        for (var s = AssetLoader.Instance.Level.Speeds.Count - 1; s >= 0; s--)
        {
            if (AssetLoader.Instance.Level.Enemies[currentEnemy].SpawnTime > AssetLoader.Instance.Level.Speeds[s].SpawnTime)
            {
                return AssetLoader.Instance.Level.Speeds[s].Speed;
            }
        }

        
        return 100;
    }
}