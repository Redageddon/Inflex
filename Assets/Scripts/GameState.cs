using Audio;
using Logic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private static bool gamePaused;
    [SerializeField] private GameObject pauseScreen;

    public void OnEnable()
    {
        AudioPlayer.Instance.LoadAudio($"{Assets.Instance.BeatMap.Path}/{Assets.Instance.BeatMap.SongFile}");
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