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
        for (var i = _offset; i < AssetLoader.Instance.Level.Enemies.Count; i++)
        {
            if (GameState.GetSpeed(_offset) * (-AudioPlayer.Instance.GetTrueAudioTime() + AssetLoader.Instance.Level.Enemies[i].SpawnTime) + 5.6 * AssetLoader.Instance.SavedSettings.ElementsSize > 1100) return;
            CreateEnemy(AssetLoader.Instance.Level.Enemies[i], GameState.GetSpeed(_offset));
            _offset ++;
        }
    }

    private void CreateEnemy(EnemyEvent self, float speed)
    {
        var enemyInstance = Instantiate(enemy, enemy.transform.parent, false);
        enemyInstance.GetComponent<HitObject>().SetVariables(self, speed);
    }
}