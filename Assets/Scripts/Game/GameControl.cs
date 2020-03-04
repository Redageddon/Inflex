using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static string MapName = Environment.ExpandEnvironmentVariables(@"%AppData%\CircleRhythm\Maps\DefaultMap");
    public static Map Map;
    private readonly List<GameObject> _hitObjectsInGame = new List<GameObject>();
    [SerializeField] private GameObject enemy;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private Text key;
    [SerializeField] private Image img;
    [SerializeField] private Text lives;

    public static bool GamePaused;

    private void Awake()
    {
        Map = JsonLoader.LoadMap(MapName);
        CreateEnemies();
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
        EnableEnemy();
        UpdatePause();
        UpdateUi();
        UpdateDeath();
    }

    private void EnableEnemy()
    {
        for (var i = 0; i < Map.Enemies.Count; i++)
        {
            if (Map.Enemies[i].Speed * (-audioSource.time + Map.Enemies[i].SpawnTime) + 2.565 * GlobalSettings.Settings.CenterSize < 1100)
            {
                _hitObjectsInGame[i].SetActive(true);
            }
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
        foreach (var keyCode in GlobalSettings.Settings.Keys.Where(Input.GetKeyDown))
        {
            key.text = keyCode.ToString();
        }

        lives.text = "Lives: " + Map.Lives;
    }

    private static void UpdateDeath()
    {
        if (Map.Lives <= 0)
        {
            SceneManager.LoadScene("MapSelection", LoadSceneMode.Single);
        }
    }

    private void CreateEnemies()
    {
        for (var i = 0; i < Map.Enemies.Count; i++)
        {
            var enemyInstance = Instantiate(enemy, enemy.transform.parent, false);
            _hitObjectsInGame.Add(enemyInstance);
            enemyInstance.name = "Enemy" + i;
            enemyInstance.GetComponent<ComplexEnemy>().CurrentEnemy = i;
        }
    }
}