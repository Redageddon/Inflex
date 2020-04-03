using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private int _offset;
    
    private void Update() 
    {
        WaitToSpawnEnemy();
    }
    
    private void WaitToSpawnEnemy()
    {
        for (var i = _offset; i < MapHandler.Instance.Map.Enemies.Count; i++)
        {
            if (GameState.GetSpeed(_offset) * (-AudioPlayer.Instance.GetTrueAudioTime() + MapHandler.Instance.Map.Enemies[i].SpawnTime) + 5.6 * SettingsHandler.Instance.SavedSettings.ElementsSize > 1100) return;
            CreateEnemy(MapHandler.Instance.Map.Enemies[i], GameState.GetSpeed(_offset));
            _offset ++;
        }
    }

    private void CreateEnemy(EnemyEvent self, float speed)
    {
        var enemyInstance = Instantiate(enemy, enemy.transform.parent, false);
        enemyInstance.GetComponent<HitObject>().SetVariables(self, speed);
    }
}