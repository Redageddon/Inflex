using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private AudioSource audioSource;
    private static bool _gamePaused;

    public void OnGUI() => UpdatePause();

    private void Update() => UpdatePause();

    private void UpdatePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _gamePaused = !_gamePaused;
            pauseScreen.SetActive(_gamePaused);
        }
        if (!_gamePaused)
        {
            audioSource.UnPause();
        }
        else
        {
            audioSource.Pause();
        }
    }
    
    public static float GetSpeed(int currentEnemy)
    {
        for (int s = Assets.Instance.Level.Speeds.Count - 1; s >= 0; s--)
        {
            if (Assets.Instance.Level.Enemies[currentEnemy].SpawnTime > Assets.Instance.Level.Speeds[s].SpawnTime)
            {
                return Assets.Instance.Level.Speeds[s].Speed;
            }
        }
        return 100;
    }
}