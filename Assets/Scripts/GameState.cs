using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    public static bool GamePaused;

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
        for (var s = Assets.Instance.Level.Speeds.Count - 1; s >= 0; s--)
        {
            if (Assets.Instance.Level.Enemies[currentEnemy].SpawnTime > Assets.Instance.Level.Speeds[s].SpawnTime)
            {
                return Assets.Instance.Level.Speeds[s].Speed;
            }
        }
        return 100;
    }
}