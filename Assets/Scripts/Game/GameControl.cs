using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static string MapName = Environment.ExpandEnvironmentVariables(@"%AppData%\CircleRhythm\Maps\DefaultMap");
    public static int CurrentKey;
    public static bool GamePaused;
    public static Map Map;
    [SerializeField] private GameObject enemy;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private Text key;
    [SerializeField] private Image img;
    [SerializeField] private Text lives;
    private int offset;

    private void Awake()
    {
        Map = JsonLoader.LoadMap(MapName);
        BackgroundChanger.SetBackground(img, Path.Combine(Map.Path, Map.Background));
    }

    private void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("MapSelection", LoadSceneMode.Single);
        }
    }

    private void Update()
    {
        UpdatePause();
        UpdateUi();
        UpdateDeath();
    }

    private void FixedUpdate()
    {
        EnableEnemy();
    }

    private void EnableEnemy()
    {
        for (var i = offset; i < Map.Enemies.Count; i++)
        {
            if (Map.Enemies[i].Speed * (-audioSource.time + Map.Enemies[i].SpawnTime) + 2.565 * GlobalSettings.Settings.CenterSize > 1100) return;
            CreateEnemy(i);
            offset += 1;
        }
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
            audioSource.UnPause();
        }
        else
        {
            audioSource.Pause();
        }
    }

    private void UpdateUi()
    {
        for (int i = 0; i < 4; i++)
        {
            if (!Input.GetKeyDown(GlobalSettings.Settings.Keys[i])) continue;
            key.text = GlobalSettings.Settings.Keys[i].ToString();
            CurrentKey = i;
        }
        
        lives.text = " Lives: " + Map.Lives;
    }

    private static void UpdateDeath()
    {
        if (Map.Lives <= 0)
        {
            SceneManager.LoadScene("MapSelection", LoadSceneMode.Single);
        }
    }

    private void CreateEnemy(int i)
    {
        var enemyInstance = Instantiate(enemy, enemy.transform.parent, false);
        enemyInstance.name = "Enemy" + i;
        enemyInstance.GetComponent<HitObject>().CurrentEnemy = i;
        enemyInstance.SetActive(true);
    }
}