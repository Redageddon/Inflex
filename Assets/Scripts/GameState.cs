using UnityEngine;

public class GameState : MonoBehaviour
{
    private static bool gamePaused;
    [SerializeField] private GameObject pauseScreen;

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

    public void OnEnable()
    {
        AudioPlayer.Instance.LoadAudio($"{Assets.Instance.Level.Path}/{Assets.Instance.Level.SongFile}");
        AudioHelper.SetOffset();
        AudioPlayer.Instance.PlayGameSong();
    }

    private void Update() => this.UpdatePause();

    private void UpdatePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePaused = !gamePaused;
            this.pauseScreen.SetActive(gamePaused);
        }

        AudioPlayer.Instance.SetAudioPaused(gamePaused);
    }
}