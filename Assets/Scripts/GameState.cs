using System;
using System.IO;
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
        for (var s = MapHandler.Instance.Map.Speeds.Count - 1; s >= 0; s--)
        {
            if (MapHandler.Instance.Map.Enemies[currentEnemy].SpawnTime > MapHandler.Instance.Map.Speeds[s].SpawnTime)
            {
                return MapHandler.Instance.Map.Speeds[s].Speed;
            }
        }

        return 100;
    }
}