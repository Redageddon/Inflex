using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static string MapName;
    public static Map Map;
    [SerializeField] private GameObject enemy;
    [SerializeField] private AudioSource audioSource;
    private int _offset;

    private void Awake()
    {
        Map = MapHandler.LoadMap(MapName);
    }

    private void Update()
    {
        WaitToSpawnEnemy();
        UpdateDeath();
    }

    private void WaitToSpawnEnemy()
    {
        for (var i = _offset; i < Map.Enemies.Count; i++)
        {
            if (GameState.Speed * (-audioSource.time + Map.Enemies[i].SpawnTime) + 2.565 * SettingsHandler.LoadSettings().CenterSize > 1100) return;
            EnemySpawner.CreateEnemy(enemy, i, GameState.Speed);
            _offset += 1;
        }
    }

    private static void UpdateDeath()
    {
        if (Map.Lives <= 0)
        {
            SceneManager.LoadScene("MapSelection", LoadSceneMode.Single);
        }
    }
}