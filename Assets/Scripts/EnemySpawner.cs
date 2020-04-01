using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Sprite[] sprites;
    private int _offset;
    
    private void Update() 
    {
        WaitToSpawnEnemy();
    }

    private void WaitToSpawnEnemy()
    {
        for (var i = _offset; i < MapHandler.Map.Enemies.Count; i++)
        {
            if (GameState.Speed * (-audioSource.time + MapHandler.Map.Enemies[i].SpawnTime) + 2.565 * SettingsHandler.LoadSettings().CenterSize > 1100) return;
            CreateEnemy(MapHandler.Map.Enemies[i], GameState.Speed);
            _offset += 1;
        }
    }

    private void CreateEnemy(EnemyEvent self, float speed)
    {
        var enemyInstance = Instantiate(enemy, enemy.transform.parent, false);
        enemyInstance.AddComponent<HitObject>().SetVariables(self, audioSource, speed, sprites[0]);
    }
}